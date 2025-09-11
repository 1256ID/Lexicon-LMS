using LMS.Shared.DTOs;
using LMS.Shared.DTOs.Courses;
using LMS.Shared.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading.Tasks;

namespace LMS.Presentation.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    private static int _nextId = 1;

    public CourseController(ICourseService courseService) => _courseService = courseService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _courseService.GetAllAsync();

        return Ok(result.Value ?? Array.Empty<CourseDto>());
    }
       

    [HttpGet("{id:int}")]
    public ActionResult<CourseDto> GetById(int id, CancellationToken ct)
    {
        var course = _courseService.GetByIdAsync(id, ct);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public ActionResult<CourseDto> Create([FromBody] CourseUpsertDto dto, CancellationToken ct)
    {
        var courseDto = new CourseDto {
            Name = dto.Name,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        _courseService.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = courseDto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update(int id, [FromBody] CourseUpsertDto body, CancellationToken ct)
    {
        var result = _courseService.UpdateAsync(id, body);
        if (result is null) return NotFound();

       
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id, CancellationToken ct)
    {
        var result = _courseService.DeleteAsync(id, ct);

        if (result is null)
            return Problem("Unexpected null result.", statusCode: 500);
        

        return NoContent();
    }
}
