namespace LMS.Blazor.Client.Models;

public class ModuleVM
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int TypeId { get; set; }
    public int DateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    // Navigation properties from related tables (for display purposes)
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? TypeName { get; set; }

    // Additional computed/display properties
    public string? CourseName { get; set; }
    public int? ActivityCount { get; set; }
    public int? Order { get; set; } // Order within course
}