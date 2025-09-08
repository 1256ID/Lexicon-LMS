using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Service.Contracts;
using LMS.Shared.DTOs.User;
using LMS.Shared.DTOs;

namespace LMS.Presentation.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;

    [HttpGet("{id:guid}")]
    public Task <ResultDto<UserDto>> GetById(string id) => _userService.GetUserByIdAsync(id);

    

}


