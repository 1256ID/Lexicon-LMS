using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;


namespace LMS.Blazor.Client.Services.Implementations;

public class MockCourseService : ICourseService
{
    private readonly List<CourseVM> _courses = new()
{
    new()
    {
        Id = 1,
        Title = "C# Fundamentals",
        Description = "Learn the basics of C# and object-oriented programming.",
        StartDate = DateTime.Parse("2025-08-14"),
        EndDate = DateTime.Parse("2025-09-05")
    },
    new()
    {
        Id = 2,
        Title = "Web Development",
        Description = "Front-end and back-end development with modern tools.",
        StartDate = DateTime.Parse("2025-09-08"),
        EndDate = DateTime.Parse("2025-10-01")
    },
    new()
    {
        Id = 3,
        Title = "Data Science",
        Description = "Data analysis, visualization, and machine learning.",
        StartDate = DateTime.Parse("2025-10-05"),
        EndDate = DateTime.Parse("2025-10-29")
    },
    new()
    {
        Id = 4,
        Title = "UI/UX Design Basics",
        Description = "Learn the principles of user interface and experience design.",
        StartDate = DateTime.Parse("2025-11-03"),
        EndDate = DateTime.Parse("2025-11-28")
    },
    new()
    {
        Id = 5,
        Title = "Cloud Computing with Azure",
        Description = "Build and deploy cloud applications on Microsoft Azure.",
        StartDate = DateTime.Parse("2025-12-01"),
        EndDate = DateTime.Parse("2025-12-24")
    }
};


    public Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => Task.FromResult(_courses.AsEnumerable());

    public Task<CourseVM?> GetCourseByIdAsync(int id)
        => Task.FromResult(_courses.FirstOrDefault(c => c.Id == id));
}
