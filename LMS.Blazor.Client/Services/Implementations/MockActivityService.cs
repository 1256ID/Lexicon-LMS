using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockActivityService : IActivityService
{
    private readonly List<ActivityVM> _activities = new()
{
    // Activities for C# Fundamentals Modules (ModuleId 1–3)
    new() { Id = 1, ModuleId = 1, Title = "Lecture: Intro to C#", Description = "Overview of C# language and environment.", StartDate = DateTime.Parse("2025-08-14 09:00"), EndDate = DateTime.Parse("2025-08-14 11:00") },
    new() { Id = 2, ModuleId = 1, Title = "Exercise: Hello World", Description = "Hands-on basic syntax exercises.", StartDate = DateTime.Parse("2025-08-14 11:30"), EndDate = DateTime.Parse("2025-08-14 13:00") },
    new() { Id = 3, ModuleId = 2, Title = "Lecture: OOP", Description = "Classes, objects, inheritance.", StartDate = DateTime.Parse("2025-08-17 09:00"), EndDate = DateTime.Parse("2025-08-17 12:00") },
    new() { Id = 4, ModuleId = 2, Title = "Workshop: OOP Practice", Description = "Hands-on OOP practice.", StartDate = DateTime.Parse("2025-08-18 10:00"), EndDate = DateTime.Parse("2025-08-18 12:00") },
    new() { Id = 5, ModuleId = 3, Title = "Assignment: Build a App", Description = "Create a small console application using learned concepts.", StartDate = DateTime.Parse("2025-08-22 00:00"), EndDate = DateTime.Parse("2025-08-28 23:59") },

    // Activities for Web Development Modules (ModuleId 4–6)
    new() { Id = 6, ModuleId = 4, Title = "Lecture: HTML & CSS ", Description = "Learn the structure and styling of web pages.", StartDate = DateTime.Parse("2025-09-08 09:00"), EndDate = DateTime.Parse("2025-09-08 11:00") },
    new() { Id = 7, ModuleId = 4, Title = "Exercise: Create a Page", Description = "Hands-on HTML & CSS practice.", StartDate = DateTime.Parse("2025-09-09 10:00"), EndDate = DateTime.Parse("2025-09-09 12:00") },
    new() { Id = 8, ModuleId = 5, Title = "Lecture:  Fundamentals", Description = "Introduction to JS and DOM manipulation.", StartDate = DateTime.Parse("2025-09-15 09:00"), EndDate = DateTime.Parse("2025-09-15 12:00") },
    new() { Id = 9, ModuleId = 5, Title = "Workshop: JS Interactive Page", Description = "Hands-on JavaScript exercises.", StartDate = DateTime.Parse("2025-09-16 10:00"), EndDate = DateTime.Parse("2025-09-16 12:00") },
    new() { Id = 10, ModuleId = 6, Title = "Assignment: Build an API", Description = "Backend API using ASP.NET.", StartDate = DateTime.Parse("2025-09-22 00:00"), EndDate = DateTime.Parse("2025-10-01 23:59") },

    // Activities for Data Science Modules (ModuleId 7–9)
    new() { Id = 11, ModuleId = 7, Title = "Lecture: Data Analysis ", Description = "Working with datasets.", StartDate = DateTime.Parse("2025-10-05 09:00"), EndDate = DateTime.Parse("2025-10-05 12:00") },
    new() { Id = 12, ModuleId = 7, Title = "Exercise: Analyze Data", Description = "Hands-on practice with datasets.", StartDate = DateTime.Parse("2025-10-06 10:00"), EndDate = DateTime.Parse("2025-10-06 12:00") },
    new() { Id = 13, ModuleId = 8, Title = "Lecture: Data Visualization", Description = "Charts and graphs with Python or Power BI.", StartDate = DateTime.Parse("2025-10-11 09:00"), EndDate = DateTime.Parse("2025-10-11 11:00") },
    new() { Id = 14, ModuleId = 9, Title = "Assignment: ML Project", Description = "Implement a simple machine learning model.", StartDate = DateTime.Parse("2025-10-21 00:00"), EndDate = DateTime.Parse("2025-10-29 23:59") }
};


    public Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId)
        => Task.FromResult(_activities.Where(a => a.ModuleId == moduleId).AsEnumerable());

    public Task<ActivityVM?> GetActivityByIdAsync(int id)
        => Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));
}

