using LMS.Blazor.Client.Models;


namespace LMS.Blazor.Client.Services.Interfaces;

public interface IActivityService
{
    // READ 
    Task<IEnumerable<ActivityVM>> GetActivitiesAsync();
    Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId);
    Task<ActivityVM?> GetActivityByIdAsync(int id);

    // CRUD 
    Task<ActivityVM> CreateActivityAsync(ActivityVM activity);
    Task<ActivityVM> UpdateActivityAsync(ActivityVM activity);
    Task<bool> DeleteActivityAsync(int id);
}