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

    // Your existing methods
    public async Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId)
        => await _http.GetFromJsonAsync<IEnumerable<ActivityVM>>($"api/modules/{moduleId}/activities")
           ?? Enumerable.Empty<ActivityVM>();

    public async Task<ActivityVM?> GetActivityByIdAsync(int id)
        => await _http.GetFromJsonAsync<ActivityVM>($"api/activities/{id}");

    // Missing methods to add:
    public async Task<IEnumerable<ActivityVM>> GetActivitiesAsync()
        => await _http.GetFromJsonAsync<IEnumerable<ActivityVM>>("api/activities")
           ?? Enumerable.Empty<ActivityVM>();

    public async Task<ActivityVM> CreateActivityAsync(ActivityVM activity)
    {
        var response = await _http.PostAsJsonAsync("api/activities", activity);
        response.EnsureSuccessStatusCode();

        var createdActivity = await response.Content.ReadFromJsonAsync<ActivityVM>();
        return createdActivity ?? throw new InvalidOperationException("Failed to create activity");
    }

    public async Task<ActivityVM> UpdateActivityAsync(ActivityVM activity)
    {
        var response = await _http.PutAsJsonAsync($"api/activities/{activity.Id}", activity);
        response.EnsureSuccessStatusCode();

        var updatedActivity = await response.Content.ReadFromJsonAsync<ActivityVM>();
        return updatedActivity ?? throw new InvalidOperationException("Failed to update activity");
    }

    public async Task<bool> DeleteActivityAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/activities/{id}");
        return response.IsSuccessStatusCode;
    }
}