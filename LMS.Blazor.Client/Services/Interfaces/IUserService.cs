using LMS.Blazor.Client.Models;
using System.Net.Http.Json;

namespace LMS.Blazor.Client.Services.Interfaces
{
    public interface IUserService 
    {
        // READ operations
        Task<IEnumerable<CourseVM>> GetUsersAsync();
        Task<CourseVM?> GetUserByIdAsync(int id);

        // UPDATE operation
        Task<CourseVM> UpdateCourseAsync(CourseVM user);

        // DELETE operation
        Task<bool> DeleteUserAsync(int id);
    }
}
