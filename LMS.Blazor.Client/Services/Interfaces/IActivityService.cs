using LMS.Blazor.Client.Models;

namespace LMS.Blazor.Client.Services;

public interface IActivityService
{
    Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId);
    Task<ActivityVM?> GetActivityByIdAsync(int id);
}
