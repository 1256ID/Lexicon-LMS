namespace LMS.Blazor.Client.Models
{
    public class DocumentVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public int TypeId { get; set; }
        public string UserId { get; set; } = string.Empty;

        // Navigation properties
        public string? TypeName { get; set; }
        public string? UploaderName { get; set; }
    }
}