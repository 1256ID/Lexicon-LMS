using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;


namespace LMS.Blazor.Client.Services.Implementations;

public class MockCourseService : ICourseService
{

private readonly List<CourseVM> _courses = new()
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


    public Task<IEnumerable<CourseVM>> GetCoursesAsync()
        => Task.FromResult(_courses.AsEnumerable());

    public Task<CourseVM?> GetCourseByIdAsync(int id)
        => Task.FromResult(_courses.FirstOrDefault(c => c.Id == id));
}
