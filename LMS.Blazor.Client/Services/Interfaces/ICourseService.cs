using LMS.Blazor.Client.Models;

namespace LMS.Blazor.Client.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseVM>> GetCoursesAsync();
    Task<CourseVM?> GetCourseByIdAsync(int id);
}
