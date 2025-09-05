using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockModuleService : IModuleService
{
    private readonly List<ModuleVM> _modules = new()
{
    // Modules for C# Fundamentals (CourseId = 1)
    new() { Id = 1, CourseId = 1, Title = "Introduction to C#", Description = "Overview of C# language and tools.", StartDate = DateTime.Parse("2025-08-14"), EndDate = DateTime.Parse("2025-08-16") },
    new() { Id = 2, CourseId = 1, Title = "OOP Concepts", Description = "Classes, objects, inheritance, and encapsulation.", StartDate = DateTime.Parse("2025-08-17"), EndDate = DateTime.Parse("2025-08-21") },
    new() { Id = 3, CourseId = 1, Title = "Working with Data", Description = "Arrays, collections, and basic LINQ.", StartDate = DateTime.Parse("2025-08-22"), EndDate = DateTime.Parse("2025-08-28") },

    // Modules for Web Development (CourseId = 2)
    new() { Id = 4, CourseId = 2, Title = "HTML & CSS Basics", Description = "Structure and style your first web pages.", StartDate = DateTime.Parse("2025-09-08"), EndDate = DateTime.Parse("2025-09-14") },
    new() { Id = 5, CourseId = 2, Title = "JavaScript Fundamentals", Description = "Interactive web pages using JS.", StartDate = DateTime.Parse("2025-09-15"), EndDate = DateTime.Parse("2025-09-21") },
    new() { Id = 6, CourseId = 2, Title = "Backend with ASP.NET", Description = "Building APIs and server-side logic.", StartDate = DateTime.Parse("2025-09-22"), EndDate = DateTime.Parse("2025-10-01") },

    // Modules for Data Science (CourseId = 3)
    new() { Id = 7, CourseId = 3, Title = "Data Analysis Basics", Description = "Working with datasets and Excel/Pandas.", StartDate = DateTime.Parse("2025-10-05"), EndDate = DateTime.Parse("2025-10-10") },
    new() { Id = 8, CourseId = 3, Title = "Data Visualization", Description = "Charts and graphs with Matplotlib and Power BI.", StartDate = DateTime.Parse("2025-10-11"), EndDate = DateTime.Parse("2025-10-20") },
    new() { Id = 9, CourseId = 3, Title = "Machine Learning", Description = "Basic ML concepts and algorithms.", StartDate = DateTime.Parse("2025-10-21"), EndDate = DateTime.Parse("2025-10-29") },

    // Modules for UI/UX Design Basics (CourseId = 4)
    new() { Id = 10, CourseId = 4, Title = "Design Principles", Description = "Color theory, typography, and layout.", StartDate = DateTime.Parse("2025-11-03"), EndDate = DateTime.Parse("2025-11-10") },
    new() { Id = 11, CourseId = 4, Title = "Wireframing & Prototyping", Description = "Create mockups and interactive prototypes.", StartDate = DateTime.Parse("2025-11-11"), EndDate = DateTime.Parse("2025-11-20") },
    new() { Id = 12, CourseId = 4, Title = "Usability Testing", Description = "Learn testing methods for UX design.", StartDate = DateTime.Parse("2025-11-21"), EndDate = DateTime.Parse("2025-11-28") },

    // Modules for Cloud Computing with Azure (CourseId = 5)
    new() { Id = 13, CourseId = 5, Title = "Azure Fundamentals", Description = "Introduction to Azure services.", StartDate = DateTime.Parse("2025-12-01"), EndDate = DateTime.Parse("2025-12-07") },
    new() { Id = 14, CourseId = 5, Title = "Deploying Apps", Description = "Publish apps using Azure App Service.", StartDate = DateTime.Parse("2025-12-08"), EndDate = DateTime.Parse("2025-12-15") },
    new() { Id = 15, CourseId = 5, Title = "Monitoring & Scaling", Description = "Learn to monitor and scale cloud apps.", StartDate = DateTime.Parse("2025-12-16"), EndDate = DateTime.Parse("2025-12-24") }
};


    public Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId)
        => Task.FromResult(_modules.Where(m => m.CourseId == courseId).AsEnumerable());

   

    public Task<ModuleVM?> GetModuleByIdAsync(int id)
        => Task.FromResult(_modules.FirstOrDefault(m => m.Id == id));
}

