using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class CourseService: ICourseService
{
    private readonly HttpClient _http;
    public CourseService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => await _http.GetFromJsonAsync<IEnumerable<CourseVM>>("api/courses")
           ?? Enumerable.Empty<CourseVM>();

    public async Task<CourseVM?> GetCourseByIdAsync(int id)
        => await _http.GetFromJsonAsync<CourseVM>($"api/courses/{id}");
}
