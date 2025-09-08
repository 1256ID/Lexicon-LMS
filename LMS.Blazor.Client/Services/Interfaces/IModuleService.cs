using LMS.Blazor.Client.Models;

namespace LMS.Blazor.Client.Services.Interfaces;

public interface IModuleService
{
  
    Task<IEnumerable<ModuleVM>> GetModulesAsync();
    Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId);
    Task<ModuleVM?> GetModuleByIdAsync(int id);

    // CRUD 
    Task<ModuleVM> CreateModuleAsync(ModuleVM module);
    Task<ModuleVM> UpdateModuleAsync(ModuleVM module);
    Task<bool> DeleteModuleAsync(int id);
}