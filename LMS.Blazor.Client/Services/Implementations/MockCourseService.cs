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
            Name = "C# Fundamentals",
            Description = "This comprehensive course introduces you to the fundamentals of C# programming and the .NET framework. You will learn basic concepts like variables, control structures, methods, as well as object-oriented programming principles. By the end of this course, you will be able to create robust console applications and understand the foundation needed to progress to more complex application development.",
            StartDate = DateTime.Parse("2025-08-14"),
            EndDate = DateTime.Parse("2025-09-05"),
            TypeId = 1,
            DateId = 1,
            TypeName = "Programming",
            TeacherName = "John Doe",
            StudentCount = 25,
            ModuleCount = 8
        },
        new()
        {
            Id = 2,
            Name = "Web Development",
            Description = "Dive into the exciting world of modern web development! This course covers both front-end development with HTML5, CSS3, JavaScript and modern frameworks like React, as well as back-end development with ASP.NET Core. You will discover web application architecture, databases, authentication, and security best practices. Hands-on projects will allow you to build complete and functional web applications.",
            StartDate = DateTime.Parse("2025-09-08"),
            EndDate = DateTime.Parse("2025-10-01"),
            TypeId = 2,
            DateId = 2,
            TypeName = "Web Development",
            TeacherName = "Jane Smith",
            StudentCount = 30,
            ModuleCount = 12
        },
        new()
        {
            Id = 3,
            Name = "Data Science",
            Description = "Explore the fascinating world of data science! This comprehensive course teaches you data analysis, visualization, applied statistics, and machine learning. You will master tools like Python, pandas, NumPy, Matplotlib, and scikit-learn. You will learn to clean and prepare data, create predictive models, and present your results clearly and convincingly. Real-world case studies will give you practical experience in various application domains.",
            StartDate = DateTime.Parse("2025-10-05"),
            EndDate = DateTime.Parse("2025-10-29"),
            TypeId = 3,
            DateId = 3,
            TypeName = "Data Science",
            TeacherName = "Dr. Brown",
            StudentCount = 20,
            ModuleCount = 10
        }
    };

    public Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => Task.FromResult(_courses.AsEnumerable());

    public Task<CourseVM?> GetCourseByIdAsync(int id)
        => Task.FromResult(_courses.FirstOrDefault(c => c.Id == id));
}
