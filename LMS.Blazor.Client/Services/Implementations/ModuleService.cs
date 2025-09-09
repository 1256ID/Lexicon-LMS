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

    public async Task<IEnumerable<ModuleVM>> GetModulesAsync()
        => await _http.GetFromJsonAsync<IEnumerable<ModuleVM>>("api/modules")
           ?? Enumerable.Empty<ModuleVM>();

    public async Task<ModuleVM> CreateModuleAsync(ModuleVM module)
    {
        var response = await _http.PostAsJsonAsync("api/modules", module);
        response.EnsureSuccessStatusCode();

        var createdModule = await response.Content.ReadFromJsonAsync<ModuleVM>();
        return createdModule ?? throw new InvalidOperationException("Failed to create module");
    }

    public async Task<ModuleVM> UpdateModuleAsync(ModuleVM module)
    {
        var response = await _http.PutAsJsonAsync($"api/modules/{module.Id}", module);
        response.EnsureSuccessStatusCode();

        var updatedModule = await response.Content.ReadFromJsonAsync<ModuleVM>();
        return updatedModule ?? throw new InvalidOperationException("Failed to update module");
    }

    public async Task<bool> DeleteModuleAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/modules/{id}");
        return response.IsSuccessStatusCode;
    }
}