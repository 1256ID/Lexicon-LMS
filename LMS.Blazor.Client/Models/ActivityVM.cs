namespace LMS.Blazor.Client.Models;

public class ActivityVM
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Länkar tillbaka till Module
    public int ModuleId { get; set; }
}
