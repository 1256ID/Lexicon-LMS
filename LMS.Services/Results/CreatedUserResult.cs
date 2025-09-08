
using LMS.Shared.DTOs.User;

namespace LMS.Services.Results;

public record CreatedUserResult(UserDto dto, string userId);

