using LMS.Blazor.Client.Models;

namespace LMS.Blazor.Client.Services;

public interface IModuleService
{
    Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId);
    Task<ModuleVM?> GetModuleByIdAsync(int id);
}
