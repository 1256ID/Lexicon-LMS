namespace LMS.Blazor.Client.Models;

/// Data model for course form submission
/// Contains only the fields that can be edited in the form

public class CourseFormData
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);
}