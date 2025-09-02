using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class ActivityService : IActivityService
{
    private readonly HttpClient _http;

    public ActivityService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId)
        => await _http.GetFromJsonAsync<IEnumerable<ActivityVM>>($"api/modules/{moduleId}/activities")
           ?? Enumerable.Empty<ActivityVM>();

    public async Task<ActivityVM?> GetActivityByIdAsync(int id)
        => await _http.GetFromJsonAsync<ActivityVM>($"api/activities/{id}");
}
