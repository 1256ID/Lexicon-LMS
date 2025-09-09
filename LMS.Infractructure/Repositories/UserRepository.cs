using AutoMapper;
using Domain.Models.Entities;
using LMS.Infractructure.Data;
using System.Security.Claims;
using LMS.Shared.DTOs;
using LMS.Shared.DTOs.User;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace LMS.Infractructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;    
    private readonly IMapper _mapper;

    public UserRepository
        (
            ApplicationDbContext db, 
            UserManager<ApplicationUser> userManager, 
            RoleManager <IdentityRole> roleManger,
            IMapper mapper
        )
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManger;
        _mapper = mapper;
    }

    public async Task<ResultDto<UserDto>> GetUserDtoById(string id, CancellationToken ct = default)
    {      
        UserDto? userDto = await _db.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email
            })
            .FirstOrDefaultAsync(ct);

        if (userDto is null)
            return ResultDto<UserDto>.Fail("User not found");        

        return userDto is null ? ResultDto<UserDto>.Fail("Not found")
                               : ResultDto<UserDto>.Ok(userDto);
    }
    public async Task<UserDto[]> GetAllUsers(CancellationToken ct = default)
    {     
        return await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.LastName)
            .Select(u => new UserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email
            })
            .ToArrayAsync(ct);
    }
    public async Task<ResultDto<string>> CreateUserAsync(UserRegistrationDto dto, CancellationToken ct = default)
    {      
        ApplicationUser user = _mapper.Map<ApplicationUser>(dto);
        user.UserName = await GenerateUserNameAsync(dto.FirstName, dto.LastName, ct);

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return ResultDto<string>.Fail(result.Errors.Select(e => e.Description).ToArray());

        
        await _userManager.AddClaimsAsync
            (
                user,
                [
                    new Claim("UserId", user.Id),
                    new Claim(ApplicationClaimTypes.UserType, dto.Role)
                ]
            );

        var createdUser = await _db.Users
            .Where(user => user.Id == user.Id)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .SingleAsync(ct);

        return ResultDto<string>.Ok(user.Id);
    }

    public async Task<ResultDto> UpdateUserAsync(UpdateUserDto dto, string id, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        ApplicationUser? user = await _userManager.FindByIdAsync(id);
        if (user is null)
            return ResultDto.Fail("User not found");

        if (!string.IsNullOrEmpty(dto.FirstName))
            user.FirstName = dto.FirstName;

        if (!string.IsNullOrEmpty(dto.LastName))
            user.LastName = dto.LastName;

        if ((!string.IsNullOrEmpty(dto.Email)) && !string.Equals(dto.Email, user.Email, StringComparison.OrdinalIgnoreCase))
        {
            var existing = await _userManager.FindByEmailAsync(dto.Email);

            if (existing != null && existing.Id != user.Id)
                return ResultDto.Fail("Email is already in use");

            var setEmail = await _userManager.SetEmailAsync(user, dto.Email);
            if (!setEmail.Succeeded)
                return ResultDto.Fail(setEmail.Errors.Select(e => e.Description).ToArray());         
        }
            user.Email = dto.Email;

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded
            ? ResultDto.Ok()
            : ResultDto.Fail(result.Errors.Select(e => e.Description).ToArray());

    }
    public async Task<ResultDto> DeleteUserAsync(string id, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        ApplicationUser? user = await _userManager.FindByIdAsync(id);

        if (user is null) 
            return ResultDto.Fail("User not found");           

        var result = await _userManager.DeleteAsync(user);

        return result.Succeeded
            ? ResultDto.Ok()
            : ResultDto.Fail(result.Errors.Select(e => e.Description).ToArray());
    }

    // Roles

    public async Task<ResultDto<IReadOnlyList<UserDto>>> GetUsersInRoleAsync(string role, CancellationToken ct = default)
    {       
        if (string.IsNullOrEmpty(role))
            return ResultDto<IReadOnlyList<UserDto>>.Fail("Role is required");

        ct.ThrowIfCancellationRequested();

        var users = await _userManager.GetUsersInRoleAsync(role);

        ct.ThrowIfCancellationRequested();

        var dtos = _mapper.Map<List<UserDto>>(users);

        return ResultDto<IReadOnlyList<UserDto>>.Ok(dtos);
    }
    public async Task<ResultDto> AddToRoleAsync(string userId, string role, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return ResultDto.Fail();

        if (await _userManager.IsInRoleAsync(user, role))
            return ResultDto.Ok();

        var result = await _userManager.AddToRoleAsync(user, role);

        return result.Succeeded
            ? ResultDto.Ok()
            : ResultDto.Fail(result.Errors.Select(e => e.Description).ToArray());
    }
    public async Task<ResultDto> RemoveFromRoleAsync(string userId, string role, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) 
            return ResultDto.Fail();

        if (!await _userManager.IsInRoleAsync(user, role))
            return ResultDto.Ok();

        var result = await _userManager.RemoveFromRoleAsync(user, role);

        return result.Succeeded
            ? ResultDto.Ok()
            : ResultDto.Fail( result.Errors.Select(e => e.Description).ToArray());
    }
    

    // Utility methods

    private async Task<string> GenerateUserNameAsync(string firstName, string lastName, CancellationToken ct)
    {
        var rnd = new Random();
        string userName = "";
        var initials = string.Concat
            (
                firstName?.FirstOrDefault() ?? 'x', 
                lastName?.FirstOrDefault() ?? 'x'
            ).ToLower();
        do
        {
            var suffix = rnd.Next(1, 1000).ToString("D3");
            userName = $"{initials}{suffix}";

        } while (await _db.Users.AnyAsync(u => u.UserName == userName, ct));

        return userName;
    }
}
