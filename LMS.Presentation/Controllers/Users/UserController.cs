using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Service.Contracts;
using LMS.Shared.DTOs.User;
using LMS.Shared.DTOs;
using LMS.Shared.DTOs.AuthDtos;

namespace LMS.Presentation.Controllers.Users;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;

    [Authorize (Policy = "IsTeacher")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id, CancellationToken ct)
    {

        var result = await _userService.GetUserByIdAsync(id, ct);
        if (result is null)
            return Problem("Unexpected null result.", statusCode: 500);

        if (!result.Succeded || result.Value is null)
            return NotFound();

        return Ok(result.Value);                    
    }

    [Authorize(Policy = "TeacherOrStudentClaim")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken ct)
    {
            var users = await _userService.GetAllUsersAsync(ct);        
            return Ok(users ?? Array.Empty<UserDto>());     
    }

    [Authorize(Policy = "TeacherOrStudentClaim")]
    [HttpPut("{id}/edit")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto dto, CancellationToken ct)
    {
        var result = await _userService.UpdateUserAsync(dto, id, ct);
        if (result is null)
            return Problem("Unexpected null result.", statusCode: 500);
        if (!result.Succeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [Authorize(Policy = "IsTeacher")]
    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteUser(string id, CancellationToken ct)
    {
        var result = await _userService.DeleteUserAsync(id, ct);
        if (result is null)
            return Problem("Unexpected null result.", statusCode: 500);
        if (!result.Succeded)
            return BadRequest(result.Errors);

        return NoContent();
    }

}


