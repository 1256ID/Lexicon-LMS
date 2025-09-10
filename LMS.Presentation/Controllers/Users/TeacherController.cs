using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Service.Contracts;
using LMS.Shared.DTOs.User;
using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;
using Microsoft.AspNetCore.Http;

namespace LMS.Presentation.Controllers.Users;

[Authorize(Roles = "Teacher")]
[ApiController]
public class TeacherController : Controller
{
    private readonly IUserService _userService;
    public TeacherController(IUserService userService) => _userService = userService;

    [HttpGet("api/teacher/overview")]  
    public async Task<IActionResult> GetTeacherById(CancellationToken ct)
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

    [HttpGet("api/teachers")]
    public async Task<IActionResult> GetAllTeachers(CancellationToken ct)
    {     
            var result = await _userService.GetAllTeachersAsync(ct);

            if (result == null)
                return Problem("Unexpected null result.", statusCode: 500);

            if (!result.Succeded)
                return BadRequest(result.Errors);
                                    
            return Ok(result.Value ?? Array.Empty<UserDto>());           
    }

   
}