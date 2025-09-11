using LMS.Shared.DTOs.Courses;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private static readonly List<CourseDto> _courses = new();
    private static int _nextId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<CourseDto>> GetAll()
        => Ok(_courses);

    [HttpGet("{id:int}")]
    public ActionResult<CourseDto> GetById(int id)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public ActionResult<CourseDto> Create([FromBody] CourseUpsertDto body)
    {
        var dto = new CourseDto {
            Id = _nextId++,
            Name = body.Name,
            Description = body.Description,
            StartDate = body.StartDate,
            EndDate = body.EndDate
        };

        _courses.Add(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CourseDto> Update(int id, [FromBody] CourseUpsertDto body)
    {
        var existing = _courses.FirstOrDefault(c => c.Id == id);
        if (existing is null) return NotFound();

        var updated = existing with {
            Name = body.Name,
            Description = body.Description,
            StartDate = body.StartDate,
            EndDate = body.EndDate
        };

        var idx = _courses.FindIndex(c => c.Id == id);
        _courses[idx] = updated;

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = _courses.FirstOrDefault(c => c.Id == id);
        if (existing is null) return NotFound();

        _courses.Remove(existing);
        return NoContent();
    }
}
