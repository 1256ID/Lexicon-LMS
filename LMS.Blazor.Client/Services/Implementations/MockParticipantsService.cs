// Services/Implementations/MockParticipantsService.cs
using static LMS.Blazor.Client.Components.Participants.CourseParticipantsTeacher;

public class MockParticipantsService : IParticipantsService
{
    private static Dictionary<int, List<ParticipantDto>> _courseParticipants = new()
    {
        [1] = new List<ParticipantDto>
        {
            new() { Id = 100, Name = "Dr. Jane Smith", Email = "jane.smith@school.edu", Role = "Teacher" },
            new() { Id = 1, Name = "John Doe", Email = "john.d@student.edu", Role = "Student"},
            new() { Id = 2, Name = "Alice Johnson", Email = "alice.j@student.edu", Role = "Student" },
            new() { Id = 3, Name = "Maim Farmer", Email = "maxim.f@student.edu", Role = "Student" },
        }
    };

    private static List<AvailableStudentDto> _allStudents = new()
    {
        new() { Id = 4, Name = "Charlie Davis", Email = "charlie.d@student.edu" },
        new() { Id = 5, Name = "Diana Miller", Email = "diana.m@student.edu" }
    };

    public async Task<List<ParticipantDto>> GetCourseParticipantsAsync(int courseId)
    {
        await Task.Delay(500);
        return _courseParticipants.GetValueOrDefault(courseId, new List<ParticipantDto>());
    }

    public async Task<List<AvailableStudentDto>> SearchAvailableStudentsAsync(string searchTerm, int excludeCourseId)
    {
        await Task.Delay(300);
        var enrolledIds = _courseParticipants.GetValueOrDefault(excludeCourseId, new())
            .Where(p => p.Role == "Student").Select(p => p.Id).ToList();

        return _allStudents
            .Where(s => !enrolledIds.Contains(s.Id))
            .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                       s.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task<bool> AddStudentToCourseAsync(int courseId, int studentId)
    {
        await Task.Delay(500);
        var student = _allStudents.FirstOrDefault(s => s.Id == studentId);
        if (student != null)
        {
            if (!_courseParticipants.ContainsKey(courseId))
                _courseParticipants[courseId] = new List<ParticipantDto>();

            _courseParticipants[courseId].Add(new ParticipantDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Role = "Student",
            });
            return true;
        }
        return false;
    }

    public async Task<bool> RemoveStudentFromCourseAsync(int courseId, int studentId)
    {
        await Task.Delay(500);
        if (_courseParticipants.ContainsKey(courseId))
        {
            var student = _courseParticipants[courseId].FirstOrDefault(p => p.Id == studentId);
            if (student != null)
            {
                _courseParticipants[courseId].Remove(student);
                return true;
            }
        }
        return false;
    }
}