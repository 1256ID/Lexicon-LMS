using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockActivityService : IActivityService
{
    private static readonly List<ActivityVM> _activities = new()
    {
        // Activities for C# Fundamentals Modules (ModuleId 1–3)
        new()
        {
            Id = 1,
            Name = "Lecture: Intro to C#",
            Description = "Comprehensive overview of the C# programming language and its development environment. This introductory session covers the history and evolution of C#, its place within the .NET ecosystem, and fundamental programming concepts. Students will learn about data types, variables, operators, and basic syntax through interactive demonstrations and practical examples.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-08-14 09:00"),
            EndDate = DateTime.Parse("2025-08-14 11:00"),
            ModuleId = 1,
            TypeId = 1,
            DateId = 1,
        },
        new()
        {
            Id = 2,
            Name = "Exercise: Hello World",
            Description = "Hands-on basic syntax exercises designed to reinforce fundamental C# programming concepts. Students will create multiple variations of console applications, practice variable declarations, work with different data types, and implement basic input/output operations. Each task builds upon the previous one, gradually introducing more complex programming structures.",
            TypeName = "Exercise",
            StartDate = DateTime.Parse("2025-08-14 11:30"),
            EndDate = DateTime.Parse("2025-08-14 13:00"),
            ModuleId = 1,
            TypeId = 2,
            DateId = 2,
        },
        new()
        {
            Id = 3,
            Name = "Lecture: OOP",
            Description = "In-depth exploration of Object-Oriented Programming principles in C#. This comprehensive lecture covers the four pillars of OOP: encapsulation, inheritance, polymorphism, and abstraction. Students will learn how to design and implement classes, understand access modifiers, create constructors and destructors, and work with properties and methods.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-08-17 09:00"),
            EndDate = DateTime.Parse("2025-08-17 12:00"),
            ModuleId = 2,
            TypeId = 1,
            DateId = 3,
        },
        new()
        {
            Id = 4,
            Name = "Workshop: OOP Practice",
            Description = "Interactive workshop focusing on practical application of object-oriented programming concepts. Students will design and implement a complete class hierarchy for a real-world scenario, practicing inheritance relationships, method overriding, and polymorphic behavior. The workshop includes collaborative coding sessions and code review exercises.",
            TypeName = "Workshop",
            StartDate = DateTime.Parse("2025-08-18 10:00"),
            EndDate = DateTime.Parse("2025-08-18 12:00"),
            ModuleId = 2,
            TypeId = 3,
            DateId = 4,
        },
        new()
        {
            Id = 5,
            Name = "Assignment: Build a Console App",
            Description = "Comprehensive project assignment that combines all learned C# fundamentals into a functional console application. Students will design and develop a complete application demonstrating proper use of variables, control structures, methods, classes, and object-oriented principles. The project requires implementing user input validation, error handling, and following coding standards.",
            TypeName = "Assignment",
            StartDate = DateTime.Parse("2025-08-22 00:00"),
            EndDate = DateTime.Parse("2025-08-28 23:59"),
            ModuleId = 3,
            TypeId = 4,
            DateId = 5,
        },

        // Activities for Web Development Modules (ModuleId 4–6)
        new()
        {
            Id = 6,
            Name = "Lecture: HTML & CSS Fundamentals",
            Description = "Comprehensive introduction to web page structure and styling using HTML5 and CSS3. This lecture covers semantic HTML elements, proper document structure, accessibility considerations, and modern CSS techniques including Flexbox and Grid layouts. Students will learn about responsive design principles, CSS selectors, specificity, and the box model.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-09-08 09:00"),
            EndDate = DateTime.Parse("2025-09-08 11:00"),
            ModuleId = 4,
            TypeId = 1,
            DateId = 6,
        },
        new()
        {
            Id = 7,
            Name = "Exercise: Create a Webpage",
            Description = "Hands-on HTML and CSS practice session where students build a complete responsive webpage from scratch. The exercise involves creating a multi-section website with navigation, forms, media content, and interactive elements. Students will practice implementing CSS Grid and Flexbox layouts, creating responsive images, and ensuring accessibility compliance.",
            TypeName = "Exercise",
            StartDate = DateTime.Parse("2025-09-09 10:00"),
            EndDate = DateTime.Parse("2025-09-09 12:00"),
            ModuleId = 4,
            TypeId = 2,
            DateId = 7,
        },
        new()
        {
            Id = 8,
            Name = "Lecture: JavaScript Fundamentals",
            Description = "Comprehensive introduction to JavaScript programming language and DOM manipulation. This extensive lecture covers JavaScript syntax, data types, functions, scope, closures, and asynchronous programming with promises and async/await. Students will learn about event handling, DOM traversal and manipulation, AJAX requests, and modern ES6+ features.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-09-15 09:00"),
            EndDate = DateTime.Parse("2025-09-15 12:00"),
            ModuleId = 5,
            TypeId = 1,
            DateId = 8,
        },
        new()
        {
            Id = 9,
            Name = "Workshop: JS Interactive Page",
            Description = "Interactive workshop focused on creating dynamic web pages using JavaScript. Students will build a fully functional interactive application incorporating event listeners, DOM manipulation, local storage, and API integration. The workshop covers debugging techniques, browser developer tools usage, and implementation of common JavaScript design patterns.",
            TypeName = "Workshop",
            StartDate = DateTime.Parse("2025-09-16 10:00"),
            EndDate = DateTime.Parse("2025-09-16 12:00"),
            ModuleId = 5,
            TypeId = 3,
            DateId = 9,
        },
        new()
        {
            Id = 10,
            Name = "Assignment: Build a Web API",
            Description = "Comprehensive backend development project using ASP.NET Core to create a RESTful web API. Students will design and implement a complete API with CRUD operations, authentication, authorization, and data validation. The assignment includes database integration with Entity Framework, implementing proper HTTP status codes, and creating comprehensive API documentation.",
            TypeName = "Assignment",
            StartDate = DateTime.Parse("2025-09-22 00:00"),
            EndDate = DateTime.Parse("2025-10-01 23:59"),
            ModuleId = 6,
            TypeId = 4,
            DateId = 10,
        },

        // Activities for Data Science Modules (ModuleId 7–9)
        new()
        {
            Id = 11,
            Name = "Lecture: Data Analysis with Python",
            Description = "Comprehensive introduction to data analysis using Python and its powerful libraries including Pandas, NumPy, and SciPy. This lecture covers data import/export, data cleaning and preprocessing, exploratory data analysis techniques, and statistical analysis methods. Students will learn about handling missing data, data transformation, and working with different data formats.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-10-05 09:00"),
            EndDate = DateTime.Parse("2025-10-05 12:00"),
            ModuleId = 7,
            TypeId = 1,
            DateId = 11,
        },
        new()
        {
            Id = 12,
            Name = "Exercise: Analyze Real Dataset",
            Description = "Hands-on practice session working with authentic datasets to perform comprehensive data analysis. Students will apply statistical methods, identify patterns and trends, handle data quality issues, and create meaningful insights from raw data. The exercise involves working with multiple data sources, performing joins and merges, and calculating descriptive statistics.",
            TypeName = "Exercise",
            StartDate = DateTime.Parse("2025-10-06 10:00"),
            EndDate = DateTime.Parse("2025-10-06 12:00"),
            ModuleId = 7,
            TypeId = 2,
            DateId = 12,
        },
        new()
        {
            Id = 13,
            Name = "Lecture: Data Visualization",
            Description = "Advanced session on creating compelling data visualizations using Python (Matplotlib, Seaborn, Plotly) and Power BI. This lecture covers principles of effective data visualization, choosing appropriate chart types, color theory, and storytelling with data. Students will learn to create interactive dashboards, statistical plots, and publication-ready graphics.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-10-11 09:00"),
            EndDate = DateTime.Parse("2025-10-11 11:00"),
            ModuleId = 8,
            TypeId = 1,
            DateId = 13,
        },
        new()
        {
            Id = 14,
            Name = "Assignment: Machine Learning Project",
            Description = "Capstone project implementing a complete machine learning solution from data collection to model deployment. Students will identify a real-world problem, gather and preprocess data, select appropriate algorithms, train and validate models, and evaluate performance using proper metrics. The project includes feature engineering, hyperparameter tuning, and cross-validation.",
            TypeName = "Assignment",
            StartDate = DateTime.Parse("2025-10-21 00:00"),
            EndDate = DateTime.Parse("2025-10-29 23:59"),
            ModuleId = 9,
            TypeId = 4,
            DateId = 14,
        }
    };

    private static int _nextId = 15;

    // READ 
    public Task<IEnumerable<ActivityVM>> GetActivitiesAsync()
        => Task.FromResult(_activities.AsEnumerable());

    public Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId)
        => Task.FromResult(_activities.Where(a => a.ModuleId == moduleId));

    public Task<ActivityVM?> GetActivityByIdAsync(int id)
        => Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));

    // CREATE 
    public async Task<ActivityVM> CreateActivityAsync(ActivityVM activity)
    {
        await Task.Delay(700);

        activity.Id = _nextId++;

        // Set TypeId based on TypeName
        activity.TypeId = GetTypeIdByName(activity.TypeName ?? "Other");

        // Set default values for computed properties
        activity.MaxScore = activity.TypeName == "Assignment" ? 100 : null;
        activity.Order = _activities.Count(a => a.ModuleId == activity.ModuleId) + 1;

        _activities.Add(activity);

        return activity;
    }

    // UPDATE 
    public async Task<ActivityVM> UpdateActivityAsync(ActivityVM activity)
    {
        await Task.Delay(600);

        // Find existing activity
        var existingActivity = _activities.FirstOrDefault(a => a.Id == activity.Id);
        if (existingActivity == null)
        {
            throw new InvalidOperationException($"Activity with ID {activity.Id} not found");
        }

        // Update modifiable properties
        existingActivity.Name = activity.Name;
        existingActivity.Description = activity.Description;
        existingActivity.StartDate = activity.StartDate;
        existingActivity.EndDate = activity.EndDate;
        existingActivity.TypeName = activity.TypeName;
        existingActivity.TypeId = GetTypeIdByName(activity.TypeName ?? "Other");
        existingActivity.ModuleId = activity.ModuleId;

        return existingActivity;
    }

    // DELETE 
    public async Task<bool> DeleteActivityAsync(int id)
    {
        await Task.Delay(400);

        var activity = _activities.FirstOrDefault(a => a.Id == id);
        if (activity == null)
        {
            return false; 
        }

        _activities.Remove(activity);
        return true; 
    }

    
    /// Helper method to get type ID by name
    
    private static int GetTypeIdByName(string typeName)
    {
        return typeName switch
        {
            "Lecture" => 1,
            "Exercise" => 2,
            "Workshop" => 3,
            "Assignment" => 4,
            _ => 5 // Other
        };
    }
}