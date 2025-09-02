using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockActivityService : IActivityService
{
    private readonly List<ActivityVM> _activities = new()
    {
        new() { Id = 1, Title = "Lecture: Intro to C#", Description = "First lecture", StartDate = DateTime.Parse("2025-08-15 09:00"), EndDate = DateTime.Parse("2025-08-15 12:00"), ModuleId = 1 },
        new() { Id = 2, Title = "Workshop: OOP", Description = "Hands-on OOP practice",  StartDate = DateTime.Parse("2025-08-24 10:00"), EndDate = DateTime.Parse("2025-08-24 14:00"), ModuleId = 2 },
        new() { Id = 3, Title = "Assignment: Build a Web API", Description = "First assignment", StartDate = DateTime.Parse("2025-09-02 00:00"), EndDate = DateTime.Parse("2025-09-09 23:59"), ModuleId = 3 }
    };

    public Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId)
        => Task.FromResult(_activities.Where(a => a.ModuleId == moduleId).AsEnumerable());

    public Task<ActivityVM?> GetActivityByIdAsync(int id)
        => Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));
}

