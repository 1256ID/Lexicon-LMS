using LMS.Blazor.Client.Models;
using System.Net.Http.Json;

namespace LMS.Blazor.Client.Services.Interfaces
{
    public interface IUserService 
    {
        // User
        Task<IEnumerable<UserVM>> GetUsersAsync();
        Task<UserVM?> GetUserByIdAsync(string id);
        Task<UserVM?> UpdateUserAsync(UserVM user, string id);
        Task<bool> DeleteUserAsync(string id);


        // Student
        Task<UserVM?> GetStudentByIdAsync();
        Task<IEnumerable<UserVM>> GetAllStudentsAsync();


        // Teacher
        Task<UserVM?> GetTeacherByIdAsync();
        Task<IEnumerable<UserVM>> GetAllTeachersAsync();
        Task<UserVM?> CreateStudentAsync(UserRegistrationVM dto);
        Task<UserVM?> CreateTeacherAsync(UserRegistrationVM dto);
    }
}
