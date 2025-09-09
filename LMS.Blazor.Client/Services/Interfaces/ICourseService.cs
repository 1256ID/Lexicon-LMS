using LMS.Blazor.Client.Models;

namespace LMS.Blazor.Client.Services.Interfaces;

public interface ICourseService
{
    // Existing methods 
    Task<IEnumerable<CourseVM>> GetCoursesAsync();
    Task<CourseVM?> GetCourseByIdAsync(int id);

    // New methods for CRUD operations (nouvelles méthodes pour les opérations CRUD)
    Task<CourseVM> CreateCourseAsync(CourseVM course);
    Task<CourseVM> UpdateCourseAsync(CourseVM course);
    Task<bool> DeleteCourseAsync(int id);
}