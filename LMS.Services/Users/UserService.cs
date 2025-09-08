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
        public async Task<ResultDto<UserDto>> GetUserByIdAsync(string id) 
            => await unitOfWork.UserRepository.GetUserDtoById(id);

        // GET ALL
        public async Task<UserDto[]> GetAllUsersAsync() 
            => await unitOfWork.UserRepository.GetAllUsers();
        public async Task <ResultDto<IReadOnlyList<UserDto>>> GetAllStudentsAsync() 
            => await unitOfWork.UserRepository.GetUsersInRoleAsync("Student");     
        public async Task<ResultDto<IReadOnlyList<UserDto>>> GetAllTeachersAsync() 
            => await unitOfWork.UserRepository.GetUsersInRoleAsync("Teacher");

        // CREATE      
        public async Task<ResultDto<UserDto>> CreateStudentAsync(UserRegistrationDto dto, CancellationToken ct)
        {
            var createdStudent = await unitOfWork.UserRepository.CreateUserAsync(dto, ct);
            if (!createdStudent.Succeded)
                return ResultDto<UserDto>.Fail(createdStudent.Errors.ToArray());
            
            var addRole = await unitOfWork.UserRepository.AddToRoleAsync(createdStudent.Value!, "Student");

            if (!addRole.Succeded)
                return ResultDto<UserDto>.Fail(addRole.Errors.ToArray());

            var result = await unitOfWork.UserRepository.GetUserDtoById(createdStudent.Value!);          

            if (!result.Succeded)
                return ResultDto<UserDto>.Fail(result.Errors.ToArray());

            var userDto = result.Value!;

            return ResultDto<UserDto>.Ok(userDto);
        }
        public async Task<ResultDto<UserDto>> CreateTeacherAsync(UserRegistrationDto dto, CancellationToken ct)
        {
            var createdTeacher = await unitOfWork.UserRepository.CreateUserAsync(dto, ct);
            if (!createdTeacher.Succeded)
                return ResultDto<UserDto>.Fail(createdTeacher.Errors.ToArray());

            var addRole = await unitOfWork.UserRepository.AddToRoleAsync(createdTeacher.Value!, "Teacher");

            if (!addRole.Succeded)
                return ResultDto<UserDto>.Fail(addRole.Errors.ToArray());

            var result = await unitOfWork.UserRepository.GetUserDtoById(createdTeacher.Value!);

            if (!result.Succeded)
                return ResultDto<UserDto>.Fail(result.Errors.ToArray());

            var userDto = result.Value!;

            return ResultDto<UserDto>.Ok(userDto);
        }

        // UPDATE/DELETE
        public async Task<ResultDto> UpdateUserAsync(UpdateUserDto dto, string id) => await unitOfWork.UserRepository.UpdateUserAsync(dto, id);
        public async Task<ResultDto> DeleteUserAsync(string id) => await unitOfWork.UserRepository.DeleteUserAsync(id);
    }
}
