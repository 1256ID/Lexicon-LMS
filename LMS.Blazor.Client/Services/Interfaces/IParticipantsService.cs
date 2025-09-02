// Services/Interfaces/IParticipantsService.cs
using static LMS.Blazor.Client.Components.Participants.CourseParticipantsTeacher;

public interface IParticipantsService
{
    Task<List<ParticipantDto>> GetCourseParticipantsAsync(int courseId);
    Task<List<AvailableStudentDto>> SearchAvailableStudentsAsync(string searchTerm, int excludeCourseId);
    Task<bool> AddStudentToCourseAsync(int courseId, int studentId);
    Task<bool> RemoveStudentFromCourseAsync(int courseId, int studentId);
}