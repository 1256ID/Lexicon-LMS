using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Overview
{
    public record TeacherOverviewDto
    {
        public int TotalStudents { get; init; }
        public int ActiveCourses { get; init; }
        public int TotalModules { get; init; }
        public int PendingAssignments { get; init; }
        public int ThisWeekActivities { get; init; }

        public List<UpcomingDeadlineDto> UpcomingDeadlines { get; init; } = new();
        public List<TeacherCourseDto> TeacherCourses { get; init; } = new();
    }

    public record UpcomingDeadlineDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string CourseName { get; init; } = string.Empty;
        public DateTime DueDate { get; init; }
        public bool IsUrgent { get; init; }
    }

    public record TeacherCourseDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int StudentCount { get; init; }
        public DateTime StartDate { get; init; }
    }
}
