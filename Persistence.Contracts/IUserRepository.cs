using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;
using Domain.Models.Entities;


namespace Persistence.Contracts;

public interface IUserRepository
{
    Task<ResultDto<UserDto>> GetUserDtoById(string id, CancellationToken ct = default);
    Task<UserDto[]> GetAllUsers(CancellationToken ct = default);
    Task<ResultDto<string>> CreateUserAsync(UserRegistrationDto dto, CancellationToken ct = default);
    Task<ResultDto> UpdateUserAsync(UpdateUserDto dto, string id, CancellationToken ct = default);
    Task<ResultDto> DeleteUserAsync(string id, CancellationToken ct = default);
    Task<ResultDto<IReadOnlyList<UserDto>>> GetUsersInRoleAsync(string role, CancellationToken ct = default);
    Task<ResultDto> AddToRoleAsync(string userId, string role, CancellationToken ct = default);
    Task<ResultDto> RemoveFromRoleAsync(string userId, string role, CancellationToken ct = default);
}
