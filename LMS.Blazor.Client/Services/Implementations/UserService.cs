using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class UserService : IUserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }

    // Users

    // READ operations
    public async Task<IEnumerable<CourseVM>> GetUsersAsync()
        => await _http.GetFromJsonAsync<IEnumerable<CourseVM>>("api/users")
           ?? Enumerable.Empty<CourseVM>();

    public async Task<CourseVM?> GetUserByIdAsync(int id)
        => await _http.GetFromJsonAsync<CourseVM>($"api/users/{id}"); 

    // UPDATE operation
    public async Task<CourseVM> UpdateUsersAsync(CourseVM user)
    {
        var response = await _http.PutAsJsonAsync($"api/users/{user.Id}/edit", user);
        response.EnsureSuccessStatusCode();

        var updatedUser = await response.Content.ReadFromJsonAsync<CourseVM>();
        return updatedUser ?? throw new InvalidOperationException("Failed to update course");
    }

    // DELETE operation
    public async Task<bool> DeleteUserAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/users/{id}/delete");
        return response.IsSuccessStatusCode;
    }

    // Students


}