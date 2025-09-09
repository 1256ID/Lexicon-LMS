using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockCourseService : ICourseService
{
    // Static list to simulate database - data persists across component instances
    private static readonly List<CourseVM> _courses = new()
    {
        new()
        {
            Id = 1,
            Name = "C# Fundamentals",
            Description = "This comprehensive course introduces you to the fundamentals of C# programming and the .NET framework. You will learn basic concepts like variables, control structures, methods, as well as object-oriented programming principles. By the end of this course, you will be able to create robust console applications and understand the foundation needed to progress to more complex application development.",
            StartDate = DateTime.Parse("2025-08-14"),
            EndDate = DateTime.Parse("2025-09-05"),
            TypeId = 1,
            DateId = 1,
            TypeName = "Programming",
            TeacherName = "John Doe",
            StudentCount = 25,
            ModuleCount = 3
        },
        new()
        {
            Id = 2,
            Name = "Web Development",
            Description = "Master modern web development technologies and frameworks in this hands-on course. You will learn front-end development with HTML5, CSS3, and JavaScript, as well as back-end development using ASP.NET Core. The course covers responsive design, API development, database integration, and deployment strategies. Students will build real-world projects demonstrating full-stack development skills.",
            StartDate = DateTime.Parse("2025-09-08"),
            EndDate = DateTime.Parse("2025-10-01"),
            TypeId = 1,
            DateId = 2,
            TypeName = "Programming",
            TeacherName = "Jane Smith",
            StudentCount = 30,
            ModuleCount = 3
        },
        new()
        {
            Id = 3,
            Name = "Data Science",
            Description = "Dive into the world of data science and analytics with Python and machine learning. This course covers data manipulation with Pandas, statistical analysis, data visualization techniques, and machine learning algorithms. Students will learn to extract insights from real datasets, create compelling visualizations, and build predictive models. The curriculum includes hands-on projects using industry-standard tools and methodologies.",
            StartDate = DateTime.Parse("2025-10-05"),
            EndDate = DateTime.Parse("2025-10-29"),
            TypeId = 2,
            DateId = 3,
            TypeName = "Data Science",
            TeacherName = "Dr. Michael Chen",
            StudentCount = 22,
            ModuleCount = 3
        },
        new()
        {
            Id = 4,
            Name = "UI/UX Design Basics",
            Description = "Learn the fundamental principles of user interface and user experience design. This course covers design thinking methodology, user research techniques, wireframing, prototyping, and usability testing. Students will master industry-standard design tools like Figma and Adobe XD while creating intuitive and accessible digital experiences. The curriculum emphasizes human-centered design and current best practices in digital product design.",
            StartDate = DateTime.Parse("2025-11-03"),
            EndDate = DateTime.Parse("2025-11-28"),
            TypeId = 3,
            DateId = 4,
            TypeName = "Design",
            TeacherName = "Sarah Johnson",
            StudentCount = 18,
            ModuleCount = 4
        },
        new()
        {
            Id = 5,
            Name = "Cloud Computing with Azure",
            Description = "Build and deploy scalable cloud applications using Microsoft Azure platform. This comprehensive course covers Azure services including virtual machines, app services, databases, and storage solutions. Students will learn cloud architecture patterns, security best practices, DevOps integration, and cost optimization strategies. Hands-on labs include deploying real applications and implementing CI/CD pipelines in Azure environment.",
            StartDate = DateTime.Parse("2025-12-01"),
            EndDate = DateTime.Parse("2025-12-24"),
            TypeId = 4,
            DateId = 5,
            TypeName = "Cloud Computing",
            TeacherName = "Robert Anderson",
            StudentCount = 20,
            ModuleCount = 5
        }
    };

    // Counter for generating new IDs
    private static int _nextId = 6;

    // READ 
    public Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => Task.FromResult(_courses.AsEnumerable());

    public Task<CourseVM?> GetCourseByIdAsync(int id)
        => Task.FromResult(_courses.FirstOrDefault(c => c.Id == id));

    // CREATE 
    public async Task<CourseVM> CreateCourseAsync(CourseVM course)
    {
        await Task.Delay(800);

        course.Id = _nextId++;

        // Set default values for computed properties
        course.EndDate = course.StartDate.AddDays(30); 
        course.TypeName = course.TypeName ?? "General";
        course.TeacherName = course.TeacherName ?? "Current Teacher"; 
        course.StudentCount = 0; 
        course.ModuleCount = 0; 

        // Add to collection
        _courses.Add(course);

        return course;
    }

    // UPDATE 
    public async Task<CourseVM> UpdateCourseAsync(CourseVM course)
    {
        await Task.Delay(600);

        // Find existing course
        var existingCourse = _courses.FirstOrDefault(c => c.Id == course.Id);
        if (existingCourse == null)
        {
            throw new InvalidOperationException($"Course with ID {course.Id} not found");
        }

        // Update modifiable properties
        existingCourse.Name = course.Name;
        existingCourse.Description = course.Description;
        existingCourse.StartDate = course.StartDate;
        existingCourse.TypeId = course.TypeId;
        existingCourse.DateId = course.DateId;

        // Update computed properties if provided
        if (course.EndDate != default)
        {
            existingCourse.EndDate = course.EndDate;
        }
        else
        {
            // Recalculate end date based on new start date
            existingCourse.EndDate = course.StartDate.AddDays(30);
        }

        // Update type name based on type ID
        existingCourse.TypeName = GetTypeNameById(existingCourse.TypeId);

        return existingCourse;
    }

    private static string GetTypeNameById(int typeId)
    {
        return typeId switch
        {
            1 => "Programming",
            2 => "Data Science",
            3 => "Design",
            4 => "Cloud Computing",
            _ => "Other"
        };
    }

    // DELETE 
    public async Task<bool> DeleteCourseAsync(int id)
    {
        await Task.Delay(400);

        var course = _courses.FirstOrDefault(c => c.Id == id);
        if (course == null)
        {
            return false; 
        }

        _courses.Remove(course);
        return true; 
    }
}