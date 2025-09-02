// Services/Interfaces/IParticipantsService.cs
public interface IParticipantsService
{
    Task<List<ParticipantDto>> GetCourseParticipantsAsync(int courseId);
    Task<List<AvailableStudentDto>> SearchAvailableStudentsAsync(string searchTerm, int excludeCourseId);
    Task<bool> AddStudentToCourseAsync(int courseId, int studentId);
    Task<bool> RemoveStudentFromCourseAsync(int courseId, int studentId);
}

// DTOs dans le même namespace
public class ParticipantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
}

public class AvailableStudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}