using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;

namespace Service.Contracts;

public interface IUserService
{
    Task<ResultDto<UserDto>> GetUserByIdAsync(string id);
    Task <UserDto[]> GetAllUsersAsync();
    Task<ResultDto<IReadOnlyList<UserDto>>> GetAllStudentsAsync();
    Task<ResultDto<IReadOnlyList<UserDto>>> GetAllTeachersAsync();
    Task<ResultDto<UserDto>> CreateStudentAsync(UserRegistrationDto dto, CancellationToken ct);
    Task<ResultDto<UserDto>> CreateTeacherAsync(UserRegistrationDto dto, CancellationToken ct);
    Task <ResultDto>UpdateUserAsync(UpdateUserDto dto, string id);
    Task<ResultDto> DeleteUserAsync(string id);
}
