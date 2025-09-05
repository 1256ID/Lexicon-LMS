using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;


namespace LMS.Blazor.Client.Services.Implementations;

public class MockCourseService : ICourseService
{
    private readonly List<CourseVM> _courses = new()
    {
        new() { Id = 1, Title = "C# Fundamentals", Description = "Learn the basics of C#", StartDate = DateTime.Parse("2025-08-14"), EndDate = DateTime.Parse("2025-09-05") },
        new() { Id = 2, Title = "Web Development", Description = "Front-end and back-end development", StartDate = DateTime.Parse("2025-09-08"), EndDate = DateTime.Parse("2025-10-01") },
        new() { Id = 3, Title = "Data Science", Description = "Data analysis and machine learning", StartDate = DateTime.Parse("2025-10-05"), EndDate = DateTime.Parse("2025-10-29") }
    };

    public Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => Task.FromResult(_courses.AsEnumerable());

    public Task<CourseVM?> GetCourseByIdAsync(int id)
        => Task.FromResult(_courses.FirstOrDefault(c => c.Id == id));
}
