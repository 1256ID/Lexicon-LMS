using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services.Interfaces;

namespace LMS.Blazor.Client.Services.Implementations;

public class MockActivityService : IActivityService
{
    private readonly List<ActivityVM> _activities = new()
    {
        // Module 1 - Introduction to C# and .NET activities
        new()
        {
            Id = 1,
            Name = "Welcome Lecture: C# Overview",
            Description = "An introductory lecture covering the history of C# and .NET, key concepts, and what you can build with the platform. This session sets the foundation for your learning journey and provides an overview of the development ecosystem including Visual Studio, NuGet packages, and the .NET CLI.",
            TypeName = "Lecture",
            StartDate = DateTime.Parse("2025-08-15 09:00"),
            EndDate = DateTime.Parse("2025-08-15 12:00"),
            ModuleId = 1,
            TypeId = 1,
            DateId = 1,
        },
        new()
        {
            Id = 2,
            Name = "Lab: Setting Up Development Environment",
            Description = "Hands-on laboratory session where you will install and configure your development environment. You will install Visual Studio, create your first C# project, understand project structure, and run your first 'Hello World' application. This session ensures everyone has a working development setup before proceeding with programming concepts.",
            TypeName = "Lab",
            StartDate = DateTime.Parse("2025-08-16 10:00"),
            EndDate = DateTime.Parse("2025-08-16 12:00"),
            ModuleId = 1,
            TypeId = 2,
            DateId = 2,
        },
        new()
        {
            Id = 3,
            Name = "Assignment: Basic Syntax Exercises",
            Description = "Complete a series of programming exercises to practice C# basic syntax including variables, data types, operators, and basic input/output. This assignment reinforces the concepts learned in lectures and helps you become comfortable with C# syntax. You will solve problems involving calculations, string manipulation, and conditional logic.",
            TypeName = "Assignment",
            StartDate = DateTime.Parse("2025-08-17 00:00"),
            EndDate = DateTime.Parse("2025-08-20 23:59"),
            ModuleId = 1,
            TypeId = 3,
            DateId = 3,
        },
        
        // Module 2 - Object-Oriented Programming activities
        new()
        {
            Id = 4,
            Name = "Workshop: Classes and Objects",
            Description = "Interactive workshop focusing on creating classes, instantiating objects, and understanding the relationship between them. You will design and implement several classes representing real-world entities, practice encapsulation by making fields private and creating properties, and learn about constructors and method overloading.",
            TypeName = "Workshop",
            StartDate = DateTime.Parse("2025-08-24 10:00"),
            EndDate = DateTime.Parse("2025-08-24 14:00"),
            ModuleId = 2,
            TypeId = 2,
            DateId = 4,
        },
        new()
        {
            Id = 5,
            Name = "Project: Banking System Design",
            Description = "Design and implement a simple banking system to demonstrate OOP principles. You will create Account, Customer, and Bank classes, implement inheritance with different account types (Checking, Savings), use polymorphism for different account behaviors, and apply encapsulation to protect sensitive data. This project integrates all major OOP concepts.",
            TypeName = "Project",
            StartDate = DateTime.Parse("2025-08-25 00:00"),
            EndDate = DateTime.Parse("2025-08-29 23:59"),
            ModuleId = 2,
            TypeId = 3,
            DateId = 5,
        },
        
        // Module 3 - ASP.NET Core activities
        new()
        {
            Id = 6,
            Name = "Tutorial: MVC Architecture Deep Dive",
            Description = "Comprehensive tutorial explaining the Model-View-Controller architectural pattern in ASP.NET Core. You will learn about separation of concerns, the role of each component, and how they interact to create web applications. Includes hands-on examples of creating controllers, views, and models for a sample e-commerce application.",
            TypeName = "Tutorial",
            StartDate = DateTime.Parse("2025-09-02 09:00"),
            EndDate = DateTime.Parse("2025-09-02 16:00"),
            ModuleId = 3,
            TypeId = 1,
            DateId = 6,
        },
        new()
        {
            Id = 7,
            Name = "Final Project: Build a Complete Web Application",
            Description = "Capstone project where you will build a complete web application using ASP.NET Core MVC. The application should include user authentication, CRUD operations, database integration with Entity Framework Core, and a responsive user interface. You can choose from suggested project ideas like a task management system, blog platform, or inventory management system.",
            TypeName = "Final Project",
            StartDate = DateTime.Parse("2025-09-05 00:00"),
            EndDate = DateTime.Parse("2025-09-15 23:59"),
            ModuleId = 3,
            TypeId = 3,
            DateId = 7,
        },
        
        // Web Development course activities
        new()
        {
            Id = 8,
            Name = "Responsive Design Challenge",
            Description = "Create a fully responsive website layout using HTML5 and CSS3. Your design must work perfectly on desktop, tablet, and mobile devices using flexbox and CSS Grid. The challenge includes implementing a navigation menu, hero section, card layouts, and a contact form. Focus on semantic HTML and accessibility best practices.",
            TypeName = "Challenge",
            StartDate = DateTime.Parse("2025-09-12 00:00"),
            EndDate = DateTime.Parse("2025-09-16 23:59"),
            ModuleId = 4,
            TypeId = 3,
            DateId = 8,
        },
        new()
        {
            Id = 9,
            Name = "Interactive Dashboard Project",
            Description = "Build an interactive dashboard using vanilla JavaScript and modern ES6+ features. The dashboard should fetch data from a REST API, display charts and statistics, handle user interactions, and update content dynamically. Implement features like data filtering, search functionality, and local storage for user preferences.",
            TypeName = "Project",
            StartDate = DateTime.Parse("2025-09-20 00:00"),
            EndDate = DateTime.Parse("2025-09-24 23:59"),
            ModuleId = 5,
            TypeId = 3,
            DateId = 9,
        },
        
        // Data Science course activities
        new()
        {
            Id = 10,
            Name = "Data Cleaning Workshop",
            Description = "Hands-on workshop focusing on real-world data cleaning techniques using pandas. You will work with messy datasets containing missing values, duplicates, inconsistent formatting, and outliers. Learn to identify data quality issues, apply appropriate cleaning strategies, and document your data preprocessing steps for reproducibility.",
            TypeName = "Workshop",
            StartDate = DateTime.Parse("2025-10-10 10:00"),
            EndDate = DateTime.Parse("2025-10-10 15:00"),
            ModuleId = 7,
            TypeId = 2,
            DateId = 10,
        },
        new()
        {
            Id = 11,
            Name = "Capstone: Predictive Analytics Project",
            Description = "Apply machine learning techniques to solve a real-world business problem. Choose from provided datasets in areas like customer churn prediction, sales forecasting, or fraud detection. Your solution should include exploratory data analysis, feature engineering, model selection and tuning, performance evaluation, and a presentation of business insights and recommendations.",
            TypeName  = "Capstone",
            StartDate = DateTime.Parse("2025-10-18 00:00"),
            EndDate = DateTime.Parse("2025-10-21 23:59"),
            ModuleId = 9,
            TypeId = 3,
            DateId = 11,
        }
    };

    public Task<IEnumerable<ActivityVM>> GetActivitiesByModuleIdAsync(int moduleId)
        => Task.FromResult(_activities.Where(a => a.ModuleId == moduleId).AsEnumerable());

    public Task<ActivityVM?> GetActivityByIdAsync(int id)
        => Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));
}