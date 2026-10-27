# Academix

*Academix* is an ASP.NET Core MVC web application designed to help students organize their academic activities, manage subjects, plan study tasks, and prepare for upcoming exams.

Developed as part of the **SoftUni ASP.NET Fundamentals** course, the project focuses on clean architecture, database management, authentication, and validation.

**Table of Contents**
- [About the Project](#about-the-project)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Features](#features)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Future Improvements](#future-improvements)
- [Contact](#contact)

**About the Project**

Academix is a student-oriented web application that provides a centralized place for organizing academic activities.
Users can browse subjects, add subjects to their personal collection, create and manage study tasks, and organize upcoming exams. The application also supports user authentication and uses authorization checks to protect user-specific data.

The project follows the Model-View-Controller(MVC) pattern and separates database access, business logic, view models, and presentation into different projects.

**Technologies Used**

| Technology               | Version                     | Purpose                                                |
| ------------------------ | --------------------------- | ------------------------------------------------------ |
| C#                       | 14.0                        | Main programming language                              |
| .NET                     | 10.0                        | Application platform                                   |
| ASP.NET Core MVC         | 10.0                        | Web application architecture                           |
| Entity Framework Core    | 10.0.13                     | Object-relational mapping and database access          |
| Microsoft SQL Server     | 2025 (17.0.1000.7)          | Relational database                                    |
| ASP.NET Core Identity    | 10.0.13                     | User authentication and account management             |
| Razor Views              | 10.0                        | Dynamic HTML rendering                                 |
| HTML5 and CSS3           | -                           | Page structure and styling                             |
| Bootstrap                | Verify                      | Responsive layout and UI components                    |
| JavaScript               | ES version depends on usage | Client-side functionality                              |
| Dependency Injection     | Built-in                    | Service registration and dependency management         |
| Asynchronous Programming | C# async/await              | Asynchronous database operations                       |

## ✅ Prerequisites

Before running Academix, make sure you have:

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) with the ASP.NET and web development workload
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or SQL Server Express
- [Git](https://git-scm.com/)

**Getting Started**

### 1. Clone the repository

```bash
git clone https://github.com/alexander-mehandzhiyski/Academix.git
cd Academix
```

### 2. Open the solution
  -Open `Academix.slnx` in Visual Studio.
  -Restore the NuGet packages and build the solution.

### 3. Configure the database
  -Configure the SQL Server connection string in the appropriate application configuration file. See [Configuration](#configuration) below.

### 4. Apply database migrations
  -In Visual Studio, open **Tools → NuGet Package Manager → Package Manager Console**.
  -Set `Academix.Data` as the **Default project** and run:

```powershell
Update-Database -Project Academix.Data -StartupProject Academix.Web
```

This applies the existing Entity Framework Core migrations to the configured database.

### 5. Run the application

Set `Academix.Web` as the **startup project** and run the application using Visual Studio.

Alternatively, from the solution directory, run:

```bash
dotnet run --project Academix.Web
```

Open the local URL displayed in the console.

**Project Structure**

The solution is organized into separate projects to improve maintainability and separation of concerns.

```text
Academix/
├── Academix.Data.Models 
├── Academix.Data/
│   ├── Configuration/
│   └── Migrations/
│   ├── ApplicationDbContext
├── Academix.Serices.Core/
│   ├── Interfaces/
│   └── ExamService
│   └── StudyTaskService
│   └── SubjectService
├── Academix.Web.ViewModels/
│   ├── CustomValidationAttribute/
│   ├── Exam/
│   ├── StudyTask/
│   └── Subject/
├── Academix.GCommon/
│   ├── ApplicationValidation/
│   └── DomainValidation/
└── Academix.Web/
    ├── Controllers/
    ├── Views/
    ├── wwwroot/
    ├── appsettings.json
    └── Program.cs
```

*Note: The structure above summarizes the main projects and folders. Individual files and additional folders may vary.*

**Features**

### Subject Management

- Browse available subjects.
- Add subjects to a personal collection.
- View subject details.
- Remove subjects from the personal collection.

### Study Task Management

- Create study tasks for selected subjects.
- View tasks associated with a subject.
- Edit task details and deadlines.
- Mark tasks as completed or incomplete.
- Delete tasks.

### Exam Management

- Create schedule exams for selected subjects.
- Set target grades.
- View upcoming exams.
- Edit exam details.
- Delete exams.

### Authentication and Authorization

- User registration and login through ASP.NET Core Identity.
- Authorization checks for subject, task, and exam operations.

### Validation

- Server-side model validation.
- Business rules for task deadlines and exam dates.
- Client-side validation configured.

## Usage

1. Register an account or log in.
2. Browse the available subjects.
3. Add subjects to your personal collection.
4. Open a subject to manage its study tasks.
5. Create tasks, set deadlines, and update their completion status.
6. Schedule exams and set target grades.
7. Edit or remove tasks and exams when necessary.

Available actions depend on the user's authentication status to the selected subject.

## Database Setup

Academix uses Entity Framework Core with a Code-First approach and Microsoft SQL Server.

The database context is `ApplicationDbContext`, located in the data project.

To create or update the database, apply the migrations included in the repository:

```powershell
Update-Database -Project Academix.Data -StartupProject Academix.Web
```

The database schema is managed through Entity Framework Core migrations.

## Configuration

The application requires a valid SQL Server connection string.

Configure the `DefaultConnection` entry in the appropriate configuration file used by `Academix.Web`.

Example format:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;Encrypt=False;"
  }
}
```

Replace the placeholder with a connection string suitable for your local SQL Server installation.

**Security:** Do not commit passwords, private credentials, or other sensitive information to the repository. Use local development configuration or environment variables for secrets.

If additional configuration is required by your local setup, document it before running the application.

## Future Improvements

Potential future enhancements include:

- Study progress statistics and dashboards.
- Improved academic planning tools.
- Additional filtering and sorting options.
- Further improvements to the user experience.

## Contact

**Alexander Mehandzhiyski**

GitHub: [alexander-mehandzhiyski](https://github.com/alexander-mehandzhiyski)

Project Repository: [Academix](https://github.com/alexander-mehandzhiyski/Academix)

---

*Developed as part of the SoftUni ASP.NET Fundamentals course.*
