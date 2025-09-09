using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;

namespace Service.Contracts;

public interface IUserService
{
    Task<ResultDto<UserDto>> GetUserByIdAsync(string id, CancellationToken ct = default);
    Task <UserDto[]> GetAllUsersAsync(CancellationToken ct = default);
    Task<ResultDto<IReadOnlyList<UserDto>>> GetAllStudentsAsync(CancellationToken ct = default);
    Task<ResultDto<IReadOnlyList<UserDto>>> GetAllTeachersAsync(CancellationToken ct = default);
    Task<ResultDto<UserDto>> CreateStudentAsync(UserRegistrationDto dto, CancellationToken ct = default);
    Task<ResultDto<UserDto>> CreateTeacherAsync(UserRegistrationDto dto, CancellationToken ct = default);
    Task <ResultDto>UpdateUserAsync(UpdateUserDto dto, string id, CancellationToken ct = default);
    Task<ResultDto> DeleteUserAsync(string id, CancellationToken ct = default);
}
