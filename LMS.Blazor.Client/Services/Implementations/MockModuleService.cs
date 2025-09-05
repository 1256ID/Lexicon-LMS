using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockModuleService : IModuleService
{

private readonly List<ModuleVM> _modules = new()
{
    // Modules for C# Fundamentals (CourseId = 1)
    new()
    {
        Id = 1,
        CourseId = 1,
        Name = "Introduction to C# and .NET",
        Description = "This foundational module introduces you to the .NET ecosystem and C# language. You will discover the history and evolution of .NET, different types of projects you can create, and development tools like Visual Studio. We will cover basic C# syntax, data types, variables, and your first 'Hello World' program. You will also learn coding best practices and naming conventions used in the .NET community.",
        StartDate = DateTime.Parse("2025-08-14"),
        EndDate = DateTime.Parse("2025-08-16"),
        TypeId = 1,
        DateId = 1,
        TypeName = "Lecture"
    },
    new()
    {
        Id = 2,
        CourseId = 1,
        Name = "Object-Oriented Programming Concepts",
        Description = "Dive deep into object-oriented programming fundamentals in C#. This module covers the creation and use of classes and objects, understanding encapsulation through access modifiers and properties, implementing inheritance hierarchies, and applying polymorphism. You will learn about constructors, method overriding, abstract classes, and interfaces. Practical exercises will reinforce these concepts through real-world programming scenarios.",
        StartDate = DateTime.Parse("2025-08-17"),
        EndDate = DateTime.Parse("2025-08-21"),
        TypeId = 1,
        DateId = 2,
        TypeName = "Lecture"
    },
    new()
    {
        Id = 3,
        CourseId = 1,
        Name = "Working with Data Structures",
        Description = "Master data handling in C# through comprehensive coverage of arrays, collections, and LINQ operations. You will learn to work with generic collections like List<T>, Dictionary<T,K>, and HashSet<T>. The module includes advanced topics such as custom data structures, sorting algorithms, and efficient data manipulation techniques. Hands-on exercises will demonstrate practical applications in real-world programming scenarios.",
        StartDate = DateTime.Parse("2025-08-22"),
        EndDate = DateTime.Parse("2025-08-28"),
        TypeId = 1,
        DateId = 3,
        TypeName = "Lecture"
    },

    // Modules for Web Development (CourseId = 2)
    new()
    {
        Id = 4,
        CourseId = 2,
        Name = "HTML & CSS Fundamentals",
        Description = "Build the foundation of web development with HTML5 and CSS3. This module covers semantic HTML structure, accessibility best practices, and modern CSS techniques including Flexbox and Grid layouts. You will learn responsive design principles, CSS animations, and how to create professional-looking websites. The curriculum includes hands-on projects building complete web pages from scratch using modern development workflows.",
        StartDate = DateTime.Parse("2025-09-08"),
        EndDate = DateTime.Parse("2025-09-14"),
        TypeId = 2,
        DateId = 4,
        TypeName = "Workshop"
    },
    new()
    {
        Id = 5,
        CourseId = 2,
        Name = "JavaScript Programming",
        Description = "Master client-side programming with modern JavaScript. This comprehensive module covers ES6+ syntax, DOM manipulation, event handling, and asynchronous programming with promises and async/await. You will learn about JavaScript modules, error handling, and browser APIs. Practical projects include creating interactive web applications, form validation, and consuming REST APIs to create dynamic user experiences.",
        StartDate = DateTime.Parse("2025-09-15"),
        EndDate = DateTime.Parse("2025-09-21"),
        TypeId = 2,
        DateId = 5,
        TypeName = "Workshop"
    },
    new()
    {
        Id = 6,
        CourseId = 2,
        Name = "Backend Development with ASP.NET Core",
        Description = "Learn server-side development using ASP.NET Core framework. This module covers building RESTful APIs, implementing authentication and authorization, working with Entity Framework for database operations, and following clean architecture principles. You will master dependency injection, middleware configuration, and API documentation. The curriculum includes deploying applications and implementing proper error handling and logging.",
        StartDate = DateTime.Parse("2025-09-22"),
        EndDate = DateTime.Parse("2025-10-01"),
        TypeId = 1,
        DateId = 6,
        TypeName = "Lecture"
    },

    // Modules for Data Science (CourseId = 3)
    new()
    {
        Id = 7,
        CourseId = 3,
        Name = "Data Analysis Fundamentals",
        Description = "Introduction to data analysis using Python and Pandas library. This module covers data importing, cleaning, and preprocessing techniques. You will learn statistical analysis methods, handling missing data, and exploratory data analysis. The curriculum includes working with different data formats (CSV, JSON, Excel), data transformation techniques, and creating meaningful insights from raw datasets using industry-standard tools and methodologies.",
        StartDate = DateTime.Parse("2025-10-05"),
        EndDate = DateTime.Parse("2025-10-10"),
        TypeId = 3,
        DateId = 7,
        TypeName = "Lab"
    },
    new()
    {
        Id = 8,
        CourseId = 3,
        Name = "Data Visualization Techniques",
        Description = "Master the art of data storytelling through compelling visualizations. This module covers creating charts and graphs using Matplotlib, Seaborn, and Plotly in Python, as well as building interactive dashboards with Power BI. You will learn design principles for effective visualizations, color theory, and accessibility considerations. Projects include creating publication-ready graphics and automated reporting systems.",
        StartDate = DateTime.Parse("2025-10-11"),
        EndDate = DateTime.Parse("2025-10-20"),
        TypeId = 3,
        DateId = 8,
        TypeName = "Lab"
    },
    new()
    {
        Id = 9,
        CourseId = 3,
        Name = "Machine Learning Foundations",
        Description = "Explore the fundamentals of machine learning algorithms and their practical applications. This module covers supervised and unsupervised learning techniques, feature engineering, model selection and evaluation. You will implement algorithms like linear regression, decision trees, and clustering using scikit-learn. The curriculum includes hands-on projects involving real-world datasets, model validation techniques, and performance optimization strategies.",
        StartDate = DateTime.Parse("2025-10-21"),
        EndDate = DateTime.Parse("2025-10-29"),
        TypeId = 3,
        DateId = 9,
        TypeName = "Lab"
    },

    // Modules for UI/UX Design Basics (CourseId = 4)
    new()
    {
        Id = 10,
        CourseId = 4,
        Name = "Design Principles and Theory",
        Description = "Foundation course in visual design covering essential principles like contrast, alignment, repetition, and proximity. This module explores color theory, typography selection and pairing, layout composition, and visual hierarchy. You will learn about design systems, accessibility standards, and current design trends. Practical exercises include creating mood boards, style guides, and applying design principles to real-world projects.",
        StartDate = DateTime.Parse("2025-11-03"),
        EndDate = DateTime.Parse("2025-11-10"),
        TypeId = 4,
        DateId = 10,
        TypeName = "Creative"
    },
    new()
    {
        Id = 11,
        CourseId = 4,
        Name = "Wireframing and Prototyping",
        Description = "Learn to transform ideas into tangible design solutions through wireframing and prototyping. This module covers low-fidelity and high-fidelity wireframing techniques, creating interactive prototypes using Figma and Adobe XD. You will master user flow creation, information architecture, and rapid prototyping methods. Projects include building complete app mockups and testing interaction patterns.",
        StartDate = DateTime.Parse("2025-11-11"),
        EndDate = DateTime.Parse("2025-11-20"),
        TypeId = 4,
        DateId = 11,
        TypeName = "Creative"
    },
    new()
    {
        Id = 12,
        CourseId = 4,
        Name = "User Experience Testing",
        Description = "Master user-centered design through comprehensive testing methodologies. This module covers usability testing planning and execution, user research techniques, A/B testing, and analytics interpretation. You will learn to conduct user interviews, create personas, and analyze user behavior data. The curriculum includes hands-on experience with testing tools and creating actionable recommendations based on user feedback.",
        StartDate = DateTime.Parse("2025-11-21"),
        EndDate = DateTime.Parse("2025-11-28"),
        TypeId = 4,
        DateId = 12,
        TypeName = "Creative"
    },

    // Modules for Cloud Computing with Azure (CourseId = 5)
    new()
    {
        Id = 13,
        CourseId = 5,
        Name = "Azure Platform Fundamentals",
        Description = "Comprehensive introduction to Microsoft Azure cloud platform and its core services. This module covers Azure subscription management, resource groups, virtual networks, and security fundamentals. You will learn about Azure Active Directory, identity management, and basic cloud architecture patterns. Hands-on labs include setting up Azure accounts, navigating the portal, and implementing basic security configurations.",
        StartDate = DateTime.Parse("2025-12-01"),
        EndDate = DateTime.Parse("2025-12-07"),
        TypeId = 5,
        DateId = 13,
        TypeName = "Infrastructure"
    },
    new()
    {
        Id = 14,
        CourseId = 5,
        Name = "Application Deployment and Management",
        Description = "Learn to deploy and manage applications in Azure cloud environment. This module covers Azure App Service, container deployment with Azure Container Instances, and serverless computing with Azure Functions. You will master CI/CD pipelines using Azure DevOps, configuration management, and environment-specific deployments. Projects include deploying web applications and implementing automated deployment strategies.",
        StartDate = DateTime.Parse("2025-12-08"),
        EndDate = DateTime.Parse("2025-12-15"),
        TypeId = 5,
        DateId = 14,
        TypeName = "Infrastructure"
    },
    new()
    {
        Id = 15,
        CourseId = 5,
        Name = "Monitoring, Scaling, and Optimization",
        Description = "Advanced topics in cloud application management focusing on performance monitoring, auto-scaling, and cost optimization. This module covers Azure Monitor, Application Insights, and implementing alerts and dashboards. You will learn load balancing techniques, performance tuning, and cost management strategies. The curriculum includes hands-on experience with scaling applications based on demand and optimizing Azure resources for efficiency.",
        StartDate = DateTime.Parse("2025-12-16"),
        EndDate = DateTime.Parse("2025-12-24"),
        TypeId = 5,
        DateId = 15,
        TypeName = "Infrastructure"
    }
};

public Task<IEnumerable<ModuleVM>> GetModulesByCourseIdAsync(int courseId)
        => Task.FromResult(_modules.Where(m => m.CourseId == courseId).AsEnumerable());

   

    public Task<ModuleVM?> GetModuleByIdAsync(int id)
        => Task.FromResult(_modules.FirstOrDefault(m => m.Id == id));
}

