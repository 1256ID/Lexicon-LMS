using Domain.Models.Entities;
using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;
using Persistence.Contracts;
using Service.Contracts;


namespace LMS.Services.Users
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        // GET
        public async Task<ResultDto<UserDto>> GetUserByIdAsync(string id, CancellationToken ct = default) 
            => await unitOfWork.UserRepository.GetUserDtoById(id, ct);

        // GET ALL
        public async Task<UserDto[]> GetAllUsersAsync(CancellationToken ct = default) 
            => await unitOfWork.UserRepository.GetAllUsers(ct);
        public async Task <ResultDto<IReadOnlyList<UserDto>>> GetAllStudentsAsync(CancellationToken ct = default) 
            => await unitOfWork.UserRepository.GetUsersInRoleAsync("Student", ct);     
        public async Task<ResultDto<IReadOnlyList<UserDto>>> GetAllTeachersAsync(CancellationToken ct = default) 
            => await unitOfWork.UserRepository.GetUsersInRoleAsync("Teacher", ct);

        // CREATE      
        public async Task<ResultDto<UserDto>> CreateStudentAsync(UserRegistrationDto dto, CancellationToken ct = default)
        {
            var createdStudent = await unitOfWork.UserRepository.CreateUserAsync(dto, ct);
            if (!createdStudent.Succeded)
                return ResultDto<UserDto>.Fail(createdStudent.Errors.ToArray());          
            
            var addRole = await unitOfWork.UserRepository.AddToRoleAsync(createdStudent.Value!, "Student");

            if (!addRole.Succeded)
                return ResultDto<UserDto>.Fail(addRole.Errors.ToArray());

            var result = await unitOfWork.UserRepository.GetUserDtoById(createdStudent.Value!, ct);          

            if (!result.Succeded)
                return ResultDto<UserDto>.Fail(result.Errors.ToArray());

            var userDto = result.Value!;

            return ResultDto<UserDto>.Ok(userDto);
        }
        public async Task<ResultDto<UserDto>> CreateTeacherAsync(UserRegistrationDto dto, CancellationToken ct = default)
        {
            var createdTeacher = await unitOfWork.UserRepository.CreateUserAsync(dto, ct);
            if (!createdTeacher.Succeded)
                return ResultDto<UserDto>.Fail(createdTeacher.Errors.ToArray());

            var addRole = await unitOfWork.UserRepository.AddToRoleAsync(createdTeacher.Value!, "Teacher");

            if (!addRole.Succeded)
                return ResultDto<UserDto>.Fail(addRole.Errors.ToArray());

            var result = await unitOfWork.UserRepository.GetUserDtoById(createdTeacher.Value!, ct);

            if (!result.Succeded)
                return ResultDto<UserDto>.Fail(result.Errors.ToArray());

            var userDto = result.Value!;

            return ResultDto<UserDto>.Ok(userDto);
        }

        // UPDATE/DELETE
        public async Task<ResultDto> UpdateUserAsync(UpdateUserDto dto, string id, CancellationToken ct = default) 
            => await unitOfWork.UserRepository.UpdateUserAsync(dto, id, ct);
        public async Task<ResultDto> DeleteUserAsync(string id, CancellationToken ct = default) 
            => await unitOfWork.UserRepository.DeleteUserAsync(id, ct);
    }
}
