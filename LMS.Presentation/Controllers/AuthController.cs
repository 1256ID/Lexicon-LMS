using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Swashbuckle.AspNetCore.Annotations;


namespace LMS.Presentation.Controllers;

[Route("api/auth")]
[Authorize]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager serviceManager;
    private readonly IUserService _userService;

    public AuthController(IServiceManager serviceManager, IUserService userService)
    {
        this.serviceManager = serviceManager;
        this._userService = userService;
    }

    //[HttpPost]
    //[SwaggerOperation(
    //    Summary = "Register a new user",
    //    Description = "Creates a new user account with the provided registration details."
    //)]
    //[SwaggerResponse(StatusCodes.Status201Created, "User successfully registered")]
    //[SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input or registration failed")]
    //public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistrationDto)
    //{
    //    IdentityResult result = await serviceManager.AuthService.RegisterUser(userRegistrationDto);
    //    return result.Succeeded ? StatusCode(StatusCodes.Status201Created) : BadRequest(result.Errors);
    //}

    [Authorize(Roles = "Teacher")]
    [HttpPost("register-student")]
    public async Task<ActionResult<UserDto>> CreateStudent([FromBody] UserRegistrationDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var result = await _userService.CreateStudentAsync(dto, ct);
        if (result is null)
            return Problem("Unexpected null result,", statusCode: 500);

        if (!result.Succeded || result.Value is null)
            return BadRequest(result.Errors);

        return Created(string.Empty, result);
    }

    [Authorize(Roles = "Teacher")]
    [HttpPost("register-teacher")]
    public async Task<ActionResult<UserDto>> CreateTeacher([FromBody] UserRegistrationDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var result = await _userService.CreateTeacherAsync(dto, ct);
        if (result is null)
            return Problem("Unexpected null result,", statusCode: 500);

        if (!result.Succeded || result.Value is null)
            return BadRequest(result.Errors);

        return Created(string.Empty, result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Authenticate user",
        Description = "Validates user credentials and returns a JWT token for authorization."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Authentication successful", typeof(TokenDto))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid username or password")]
    public async Task<IActionResult> Authenticate(UserAuthDto user)
    {
        if (!await serviceManager.AuthService.ValidateUserAsync(user))
            return Unauthorized();

        var tokenDto = await serviceManager.AuthService.CreateTokenAsync(addTime: true);
        return Ok(tokenDto);
    }
}
