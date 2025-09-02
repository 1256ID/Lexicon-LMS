using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class ModuleService : IModuleService
{
    private readonly HttpClient _http;

    public ModuleService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId)
        => await _http.GetFromJsonAsync<IEnumerable<ModuleVM>>($"api/courses/{courseId}/modules")
           ?? Enumerable.Empty<ModuleVM>();

    public async Task<ModuleVM?> GetModuleByIdAsync(int id)
        => await _http.GetFromJsonAsync<ModuleVM>($"api/modules/{id}");
}

