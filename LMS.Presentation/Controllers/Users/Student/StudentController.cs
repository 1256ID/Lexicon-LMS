using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Service.Contracts;
using LMS.Shared.DTOs.User;
using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;

namespace LMS.Presentation.Controllers.Users.Student;

[Authorize]
[ApiController]
public class StudentController : Controller
{
    private readonly IUserService _userService;
    public StudentController(IUserService userService) => _userService = userService;

    [Authorize(Policy = "IsStudent")]
    [HttpGet("api/student/overview")]
    public async Task<IActionResult> GetStudentById(CancellationToken ct)
    {             
        var calledId = User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? User.FindFirstValue("UserId");

        if (string.IsNullOrEmpty(calledId))
            return Unauthorized("User id is missing in claims");       
        
        var result = await _userService.GetUserByIdAsync(calledId, ct);

        if (result is null)
            return Problem("Unexpected null result.", statusCode: 500);

        if (!result.Succeded || result.Value is null)
            return NotFound();

        return Ok(result.Value);   
    }

    [Authorize(Policy = "TeacherOrStudentClaim")]
    [HttpGet]
    [Route("api/students")]
    public async Task<ActionResult<UserDto[]>> GetAllStudents(CancellationToken ct)
    {             
        var result = await _userService.GetAllStudentsAsync(ct);

        if (result == null)
            return Problem("Unexpected null result.", statusCode: 500);
        if (!result.Succeded)
            return BadRequest(result.Errors);

        return Ok(result.Value ?? Array.Empty<UserDto>());
    }

  

}