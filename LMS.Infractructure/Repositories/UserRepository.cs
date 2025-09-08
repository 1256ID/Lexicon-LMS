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

    public async Task<ResultDto<UserDto>> GetUserDtoById(string id)
    {
        ApplicationUser? user = await _db.Users.SingleOrDefaultAsync(u => u.Id.Equals(id));

        if (user is null)
            return ResultDto<UserDto>.Fail("User not found"); 

        UserDto userDto = new()
        {         
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
        };

        return ResultDto<UserDto>.Ok(userDto);
    }
    public async Task<UserDto[]> GetAllUsers()
    {
        ApplicationUser[] users = await _db.Users.ToArrayAsync();

        await _userManager.Users.ToArrayAsync();
        UserDto[] userDtos = [.. users.Select(user => new UserDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email
        })];        

        return userDtos;
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

    public async Task<ResultDto> UpdateUserAsync(UpdateUserDto dto, string id)
    {
        ApplicationUser? user = await _db.Users.SingleOrDefaultAsync(u => u.Id.Equals(id));

        if (user is null)
            return ResultDto.Fail("User not found");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;      

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded
            ? ResultDto.Ok()
            : ResultDto.Fail(result.Errors.Select(e => e.Description).ToArray());

    }
    public async Task<ResultDto> DeleteUserAsync(string id)
    {
        ApplicationUser? user = await _db.Users.SingleOrDefaultAsync(u => u.Id.Equals(id));

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
        var users = await _userManager.GetUsersInRoleAsync(role);
        var dtos = _mapper.Map<List<UserDto>>(users);

        return ResultDto<IReadOnlyList<UserDto>>.Ok(dtos.ToList());
    }
    public async Task<ResultDto> AddToRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return ResultDto.Fail();

        var result = await _userManager.AddToRoleAsync(user, role);

        return result.Succeeded
            ? ResultDto.Ok()
            : ResultDto.Fail(result.Errors.Select(e => e.Description).ToArray());
    }
    public async Task<ResultDto> RemoveFromRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) 
            return ResultDto.Fail();

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
