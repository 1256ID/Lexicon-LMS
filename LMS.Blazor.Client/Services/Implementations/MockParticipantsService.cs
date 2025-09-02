// Services/Implementations/MockParticipantsService.cs
public class MockParticipantsService : IParticipantsService
{
    private static List<ParticipantDto> _allParticipants = new()
    {
        // Teachers
        new() { Id = 100, Name = "Dr. Jane Smith", Email = "jane.smith@school.edu", Role = "Teacher" },
        new() { Id = 101, Name = "Prof. John Wilson", Email = "john.wilson@school.edu", Role = "Teacher" },
        
        // Students enrolled in courses
        new() { Id = 1, Name = "John Doe", Email = "john.doe@student.edu", Role = "Student" },
        new() { Id = 2, Name = "Alice Johnson", Email = "alice.j@student.edu", Role = "Student" },
        new() { Id = 3, Name = "Bob Wilson", Email = "bob.wilson@student.edu", Role = "Student" },
        new() { Id = 4, Name = "Emma Brown", Email = "emma.brown@student.edu", Role = "Student" }
    };

    private static List<AvailableStudentDto> _availableStudents = new()
    {
        new() { Id = 5, Name = "Charlie Davis", Email = "charlie.d@student.edu" },
        new() { Id = 6, Name = "Diana Miller", Email = "diana.m@student.edu" },
        new() { Id = 7, Name = "Frank Garcia", Email = "frank.g@student.edu" },
        new() { Id = 8, Name = "Grace Lee", Email = "grace.lee@student.edu" }
    };

    public async Task<List<ParticipantDto>> GetCourseParticipantsAsync(int courseId)
    {
        await Task.Delay(500);

        // Return same mock data for any course
        return new List<ParticipantDto>
        {
            new() { Id = 100, Name = "Dr. Jane Smith", Email = "jane.smith@school.edu", Role = "Teacher" },
            new() { Id = 1, Name = "John Doe", Email = "john.doe@student.edu", Role = "Student" },
            new() { Id = 2, Name = "Alice Johnson", Email = "alice.j@student.edu", Role = "Student" },
            new() { Id = 3, Name = "Bob Wilson", Email = "bob.wilson@student.edu", Role = "Student" },
            new() { Id = 4, Name = "Emma Brown", Email = "emma.brown@student.edu", Role = "Student" }
        };
    }

    public async Task<List<AvailableStudentDto>> SearchAvailableStudentsAsync(string searchTerm, int excludeCourseId)
    {
        await Task.Delay(300);

        return _availableStudents
            .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                       s.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task<bool> AddStudentToCourseAsync(int courseId, int studentId)
    {
        await Task.Delay(500);

        var student = _availableStudents.FirstOrDefault(s => s.Id == studentId);
        if (student != null)
        {
            // Add to enrolled participants (simulate)
            _allParticipants.Add(new ParticipantDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Role = "Student"
            });

            // Remove from available list
            _availableStudents.Remove(student);
            return true;
        }

        return false;
    }

    public async Task<bool> RemoveStudentFromCourseAsync(int courseId, int studentId)
    {
        await Task.Delay(500);

        var student = _allParticipants.FirstOrDefault(p => p.Id == studentId && p.Role == "Student");
        if (student != null)
        {
            // Remove from enrolled participants
            _allParticipants.Remove(student);

            // Add back to available list
            _availableStudents.Add(new AvailableStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            });

            return true;
        }

        return false;
    }
}