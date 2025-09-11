using LMS.Shared.DTOs;
using LMS.Shared.DTOs.Courses;
using Persistence.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services
{
    public class CourseService(IUnitOfWork unitOfWork) : ICourseService
    {
        public async Task<ResultDto<IReadOnlyList<CourseDto>>> GetAllAsync(CancellationToken ct = default) => await unitOfWork.CourseRepository.GetAllAsync(ct);
        public async Task<ResultDto<CourseDto>> GetByIdAsync(int id, CancellationToken ct = default) => await unitOfWork.CourseRepository.GetByIdAsync(id, ct);
        public async Task<ResultDto<CourseDto>> CreateAsync(CourseUpsertDto dto, CancellationToken ct = default) => await unitOfWork.CourseRepository.CreateAsync(dto, ct);
        public async Task<ResultDto<CourseDto>> UpdateAsync(int id, CourseUpsertDto dto, CancellationToken ct = default) => await unitOfWork.CourseRepository.UpdateAsync(id, dto, ct);
        public async Task<ResultDto> DeleteAsync(int id, CancellationToken ct = default) => await unitOfWork.CourseRepository.DeleteAsync(id, ct);
    }
}
