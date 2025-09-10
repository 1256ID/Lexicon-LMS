using LMS.Infractructure.Data;
using LMS.Shared.DTOs;
using LMS.Shared.DTOs.Courses;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace LMS.Infractructure.Repositories;

public class CourseRepository(ApplicationDbContext context) : ICourseRepository
{
    public async Task<ResultDto<IReadOnlyList<CourseDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var items = await context.Courses
            .AsNoTracking()
            .Select(c => new CourseDto {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            })
            .ToListAsync(ct);

        return ResultDto<IReadOnlyList<CourseDto>>.Ok(items);
    }

    public async Task<ResultDto<CourseDto>> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var c = await context.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
        if (c is null) return ResultDto<CourseDto>.Fail("Not found");

        return ResultDto<CourseDto>.Ok(new CourseDto {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            StartDate = c.StartDate,
            EndDate = c.EndDate
        });
    }

    public async Task<ResultDto<CourseDto>> CreateAsync(CourseUpsertDto dto, CancellationToken ct = default)
    {
        var entity = new Domain.Models.Entities.Course {
            Name = dto.Name,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        context.Courses.Add(entity);
        await context.SaveChangesAsync(ct);

        return ResultDto<CourseDto>.Ok(new CourseDto {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate
        });
    }

    public async Task<ResultDto<CourseDto>> UpdateAsync(int id, CourseUpsertDto dto, CancellationToken ct = default)
    {
        var entity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return ResultDto<CourseDto>.Fail("Not found");

        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.StartDate = dto.StartDate;
        entity.EndDate = dto.EndDate;

        await context.SaveChangesAsync(ct);

        return ResultDto<CourseDto>.Ok(new CourseDto {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate
        });
    }

    public async Task<ResultDto> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return ResultDto.Fail("Not found");

        context.Courses.Remove(entity);
        await context.SaveChangesAsync(ct);

        return ResultDto.Ok();
    }
}
