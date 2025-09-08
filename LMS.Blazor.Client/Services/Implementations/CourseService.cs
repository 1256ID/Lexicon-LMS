using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly HttpClient _http;

    public CourseService(HttpClient http)
    {
        _http = http;
    }

    // READ operations
    public async Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => await _http.GetFromJsonAsync<IEnumerable<CourseVM>>("api/courses")
           ?? Enumerable.Empty<CourseVM>();

    public async Task<CourseVM?> GetCourseByIdAsync(int id)
        => await _http.GetFromJsonAsync<CourseVM>($"api/courses/{id}");

    // CREATE operation
    public async Task<CourseVM> CreateCourseAsync(CourseVM course)
    {
        var response = await _http.PostAsJsonAsync("api/courses", course);
        response.EnsureSuccessStatusCode();

        var createdCourse = await response.Content.ReadFromJsonAsync<CourseVM>();
        return createdCourse ?? throw new InvalidOperationException("Failed to create course");
    }

    // UPDATE operation
    public async Task<CourseVM> UpdateCourseAsync(CourseVM course)
    {
        var response = await _http.PutAsJsonAsync($"api/courses/{course.Id}", course);
        response.EnsureSuccessStatusCode();

        var updatedCourse = await response.Content.ReadFromJsonAsync<CourseVM>();
        return updatedCourse ?? throw new InvalidOperationException("Failed to update course");
    }

    // DELETE operation
    public async Task<bool> DeleteCourseAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/courses/{id}");
        return response.IsSuccessStatusCode;
    }
}