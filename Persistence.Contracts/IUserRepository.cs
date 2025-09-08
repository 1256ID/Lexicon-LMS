using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;
using Domain.Models.Entities;


namespace Persistence.Contracts;

public interface IUserRepository
{
    Task<ResultDto<UserDto>> GetUserDtoById(string id);
    Task<UserDto[]> GetAllUsers();
    Task<ResultDto<string>> CreateUserAsync(UserRegistrationDto dto, CancellationToken ct);
    Task<ResultDto> UpdateUserAsync(UpdateUserDto dto, string id);
    Task<ResultDto> DeleteUserAsync(string id);
    Task<ResultDto<IReadOnlyList<UserDto>>> GetUsersInRoleAsync(string role, CancellationToken ct = default);
    Task<ResultDto> AddToRoleAsync(string userId, string role);
    Task<ResultDto> RemoveFromRoleAsync(string userId, string role);
}
