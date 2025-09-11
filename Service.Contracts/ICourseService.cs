using LMS.Shared.DTOs;
using LMS.Shared.DTOs.Courses;

namespace Service.Contracts;

public interface ICourseService
{
    Task<ResultDto<IReadOnlyList<CourseDto>>> GetAllAsync(CancellationToken ct = default);
    Task<ResultDto<CourseDto>> GetByIdAsync(int id, CancellationToken ct = default);
    Task<ResultDto<CourseDto>> CreateAsync(CourseUpsertDto dto, CancellationToken ct = default);
    Task<ResultDto<CourseDto>> UpdateAsync(int id, CourseUpsertDto dto, CancellationToken ct = default);
    Task<ResultDto> DeleteAsync(int id, CancellationToken ct = default);
}
