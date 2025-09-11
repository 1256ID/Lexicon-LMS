using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;
using LMS.Shared.DTOs.Courses;

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
    {
        var dtos = await _http.GetFromJsonAsync<IEnumerable<CourseDto>>("api/courses")
                   ?? Enumerable.Empty<CourseDto>();

        return dtos.Select(MapToVm);
    }

    public async Task<CourseVM?> GetCourseByIdAsync(int id)
    {
        var dto = await _http.GetFromJsonAsync<CourseDto>($"api/courses/{id}");
        return dto is null ? null : MapToVm(dto);
    }

    // CREATE operation
    public async Task<CourseVM> CreateCourseAsync(CourseVM course)
    {
        var upsert = MapToUpsert(course);

        var response = await _http.PostAsJsonAsync("api/courses", upsert);
        response.EnsureSuccessStatusCode();

        var createdDto = await response.Content.ReadFromJsonAsync<CourseDto>()
                        ?? throw new InvalidOperationException("Failed to create course");

        return MapToVm(createdDto);
    }

    // UPDATE operation
    public async Task<CourseVM> UpdateCourseAsync(CourseVM course)
    {
        var upsert = MapToUpsert(course);

        var response = await _http.PutAsJsonAsync($"api/courses/{course.Id}", upsert);
        response.EnsureSuccessStatusCode();

        var updatedDto = await response.Content.ReadFromJsonAsync<CourseDto>()
                        ?? throw new InvalidOperationException("Failed to update course");

        return MapToVm(updatedDto);
    }

    // DELETE operation
    public async Task<bool> DeleteCourseAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/courses/{id}");
        return response.IsSuccessStatusCode;
    }

    private static CourseVM MapToVm(CourseDto dto) => new() {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate
    };

    private static CourseUpsertDto MapToUpsert(CourseVM vm) =>
        new(vm.Name, vm.Description, vm.StartDate, vm.EndDate);
}
