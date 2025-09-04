using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockModuleService : IModuleService
{
    private readonly List<ModuleVM> _modules = new()
    {
        // Course 1 - C# Fundamentals modules
        new()
        {
            Id = 1,
            CourseId = 1,
            Name = "Introduction to C# and .NET",
            Description = "This foundational module introduces you to the .NET ecosystem and C# language. You will discover the history and evolution of .NET, different types of projects you can create, and development tools like Visual Studio. We will cover basic C# syntax, data types, variables, and your first 'Hello World' program. You will also learn coding best practices and naming conventions used in the .NET community.",
            StartDate = DateTime.Parse("2025-08-15"),
            EndDate = DateTime.Parse("2025-08-22"),
            TypeId = 1,
            DateId = 1,
            TypeName = "Lecture"
        },
        new()
        {
            Id = 2,
            CourseId = 1,
            Name = "Object-Oriented Programming in C#",
            Description = "Master the fundamental concepts of object-oriented programming with C#. This comprehensive module covers classes and objects, encapsulation, inheritance, and polymorphism. You will learn to design effective class hierarchies, use interfaces and abstract classes, and implement common design patterns. Practical exercises will allow you to create well-structured applications using SOLID principles.",
            StartDate = DateTime.Parse("2025-08-23"),
            EndDate = DateTime.Parse("2025-08-30"),
            TypeId = 2,
            DateId = 2,
            TypeName = "Workshop"
        },
        new()
        {
            Id = 3,
            CourseId = 1,
            Name = "ASP.NET Core Fundamentals",
            Description = "Learn to build powerful web applications using ASP.NET Core. This module covers MVC architecture, routing, controllers, views, and models. You will understand how to handle HTTP requests, work with forms, implement authentication and authorization, and connect to databases using Entity Framework Core. By the end, you will have built a complete web application from scratch.",
            StartDate = DateTime.Parse("2025-09-01"),
            EndDate = DateTime.Parse("2025-09-15"),
            TypeId = 3,
            DateId = 3,
            TypeName = "Project"
        },
        
        // Course 2 - Web Development modules
        new()
        {
            Id = 4,
            CourseId = 2,
            Name = "HTML5 and CSS3 Fundamentals",
            Description = "Build a solid foundation in modern web markup and styling. This module covers semantic HTML5 elements, accessibility best practices, CSS selectors, box model, flexbox, and CSS Grid. You will learn responsive design principles and create layouts that work across all devices. Hands-on projects include building a portfolio website and a responsive navigation system.",
            StartDate = DateTime.Parse("2025-09-10"),
            EndDate = DateTime.Parse("2025-09-17"),
            TypeId = 1,
            DateId = 4,
            TypeName = "Lecture"
        },
        new()
        {
            Id = 5,
            CourseId = 2,
            Name = "JavaScript and DOM Manipulation",
            Description = "Master client-side programming with JavaScript. This comprehensive module covers ES6+ features, DOM manipulation, event handling, asynchronous programming with promises and async/await, and modern JavaScript tools. You will build interactive web applications, handle API calls, and understand browser APIs. Projects include a task manager and an interactive dashboard.",
            StartDate = DateTime.Parse("2025-09-18"),
            EndDate = DateTime.Parse("2025-09-25"),
            TypeId = 2,
            DateId = 5,
            TypeName = "Workshop"
        },
        new()
        {
            Id = 6,
            CourseId = 2,
            Name = "React Framework Development",
            Description = "Learn modern React development including components, state management, hooks, and routing. This advanced module covers component lifecycle, context API, custom hooks, and integration with backend APIs. You will build single-page applications with proper state management and understand modern development workflows with tools like Vite and React DevTools.",
            StartDate = DateTime.Parse("2025-09-26"),
            EndDate = DateTime.Parse("2025-10-01"),
            TypeId = 3,
            DateId = 6,
            TypeName = "Project"
        },
        
        // Course 3 - Data Science modules
        new()
        {
            Id = 7,
            CourseId = 3,
            Name = "Python for Data Analysis",
            Description = "Learn Python programming specifically for data science applications. This module covers Python basics, data structures, NumPy for numerical computing, and pandas for data manipulation. You will master data cleaning techniques, handling missing values, and preparing datasets for analysis. Real-world datasets from various industries will be used for hands-on practice.",
            StartDate = DateTime.Parse("2025-10-07"),
            EndDate = DateTime.Parse("2025-10-14"),
            TypeId = 1,
            DateId = 7,
            TypeName = "Lecture"
        },
        new()
        {
            Id = 8,
            CourseId = 3,
            Name = "Data Visualization and Statistics",
            Description = "Master the art of telling stories with data through effective visualization and statistical analysis. This module covers matplotlib, seaborn, and plotly for creating compelling charts and graphs. You will learn statistical concepts, hypothesis testing, correlation analysis, and how to choose the right visualization for your data.",
            StartDate = DateTime.Parse("2025-10-15"),
            EndDate = DateTime.Parse("2025-10-22"),
            TypeId = 2,
            DateId = 8,
            TypeName = "Workshop"
        },
        new()
        {
            Id = 9,
            CourseId = 3,
            Name = "Machine Learning Fundamentals",
            Description = "Dive into the exciting world of machine learning algorithms and applications. This module covers supervised and unsupervised learning, classification and regression algorithms, model evaluation techniques, and feature engineering. You will use scikit-learn to implement various algorithms and learn when to apply different approaches. Projects include building a recommendation system and predicting stock prices.",
            StartDate = DateTime.Parse("2025-10-15"),
            EndDate = DateTime.Parse("2025-10-22"),
            TypeId = 3,
            DateId = 9,
            TypeName = "Project"
        }
    };

    public Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId)
        => Task.FromResult(_modules.Where(m => m.CourseId == courseId).AsEnumerable());

    public Task<ModuleVM?> GetModuleByIdAsync(int id)
        => Task.FromResult(_modules.FirstOrDefault(m => m.Id == id));
}

