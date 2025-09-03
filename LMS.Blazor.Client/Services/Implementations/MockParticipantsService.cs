public class MockParticipantsService : IParticipantsService
{
    private static List<ParticipantDto> _enrolledStudents = new()
    {
        new() { Id = 1, Name = "John Doe", Email = "john.doe@student.edu", Role = "Student" },
        new() { Id = 2, Name = "Alice Johnson", Email = "alice.j@student.edu", Role = "Student" },
        new() { Id = 3, Name = "Bob Wilson", Email = "bob.wilson@student.edu", Role = "Student" },
        new() { Id = 4, Name = "Emma Brown", Email = "emma.brown@student.edu", Role = "Student" }
    };


    // students already registered but not in this course
    private static List<AvailableStudentDto> _availableStudents = new()
    {
        new() { Id = 5, Name = "Charlie Davis", Email = "charlie.d@student.edu" },
        new() { Id = 6, Name = "Diana Miller", Email = "diana.m@student.edu" },
        new() { Id = 7, Name = "Frank Garcia", Email = "frank.g@student.edu" },
        new() { Id = 8, Name = "Grace Lee", Email = "grace.lee@student.edu" },
        new() { Id = 9, Name = "Henry Thomas", Email = "henry.t@student.edu" }
    };

    public async Task<List<ParticipantDto>> GetCourseParticipantsAsync(int courseId)
    {
        await Task.Delay(500);

        var participants = new List<ParticipantDto>
        {
            new() { Id = 100, Name = "Dr. Jane Smith", Email = "jane.smith@school.edu", Role = "Teacher" }
        };

        participants.AddRange(_enrolledStudents);

        return participants;
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
            _enrolledStudents.Add(new ParticipantDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Role = "Student"
            });

            _availableStudents.Remove(student);
            return true;
        }

        return false;
    }

    public async Task<bool> RemoveStudentFromCourseAsync(int courseId, int studentId)
    {
        await Task.Delay(500);

        var student = _enrolledStudents.FirstOrDefault(p => p.Id == studentId);
        if (student != null)
        {
            _enrolledStudents.Remove(student);

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