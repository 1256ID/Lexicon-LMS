using System.Net.Http.Json;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }


        // User
        public async Task<IEnumerable<UserVM>> GetUsersAsync()
            => await _http.GetFromJsonAsync<IEnumerable<UserVM>>("api/users")
               ?? Enumerable.Empty<UserVM>();

        public async Task<UserVM?> GetUserByIdAsync(string id)
            => await _http.GetFromJsonAsync<UserVM>($"api/users/{id}");

        public async Task<UserVM?> UpdateUserAsync(UserVM user, string id)
        {
            var response = await _http.PutAsJsonAsync($"api/users/{id}/edit", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserVM>();
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var response = await _http.DeleteAsync($"api/users/{id}/delete");
            return response.IsSuccessStatusCode;
        }


        // Student
        public async Task<UserVM?> GetStudentByIdAsync()
            => await _http.GetFromJsonAsync<UserVM>("api/student/overview");

        public async Task<IEnumerable<UserVM>> GetAllStudentsAsync()
            => await _http.GetFromJsonAsync<IEnumerable<UserVM>>("api/students")
               ?? Enumerable.Empty<UserVM>();

 
        // Teacher
        public async Task<UserVM?> GetTeacherByIdAsync()
            => await _http.GetFromJsonAsync<UserVM>("api/teacher/overview");

        public async Task<IEnumerable<UserVM>> GetAllTeachersAsync()
            => await _http.GetFromJsonAsync<IEnumerable<UserVM>>("api/teachers")
               ?? Enumerable.Empty<UserVM>();

        public async Task<UserVM?> CreateStudentAsync(UserRegistrationVM dto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register-student", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserVM>();
        }

        public async Task<UserVM?> CreateTeacherAsync(UserRegistrationVM dto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register-teacher", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserVM>();
        }
    }
}
