using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models.Entities;

public class ApplicationUser : IdentityUser
{
    [Required]    
    public string FirstName { get; set; } = string.Empty;
    [Required]   
    public string LastName { get; set; } = string.Empty;
    //[Required]
    //[ForeignKey("CourseId")]
    //public Guid CourseId { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
}
