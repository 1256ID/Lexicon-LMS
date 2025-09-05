using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockModuleService : IModuleService
{
    private readonly List<ModuleVM> _modules = new()
    {
        new() { Id = 1, Title = "Introduction to C#", Description = "Basics of C#", StartDate = DateTime.Parse("2025-08-15"), EndDate = DateTime.Parse("2025-08-22"), },
        new() { Id = 2, Title = "OOP in C#", Description = "Classes, objects, inheritance", StartDate = DateTime.Parse("2025-08-23"), EndDate = DateTime.Parse("2025-08-30"), },
        new() { Id = 3, Title = "ASP.NET Core", Description = "Web development with .NET", StartDate = DateTime.Parse("2025-09-01"), EndDate = DateTime.Parse("2025-09-15"), },
    };

    public Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId)
        => Task.FromResult(_modules.AsEnumerable());

    public Task<ModuleVM?> GetModuleByIdAsync(int id)
        => Task.FromResult(_modules.FirstOrDefault(m => m.Id == id));
}

