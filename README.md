# PracticeApp - ASP.NET Core Web API with ADO.NET, SQLite, and SOLID Principles. 🔥

## Project Overview 🍀 📜

`PracticeApp` is an ASP.NET Core Web API application that follows SOLID Principles, leveraging ADO.NET disconnected architecture for database interaction (SQLite) using the Generic Repository Pattern. The application is structured into three primary layers: **API**, **Core**, and **Data**, with unit testing for the business logic and repository layers.

### Features 🚀 ⚖️

- **API Layer (WebAPI)**: Exposes HTTP endpoints to interact with the application.
- **Core Layer**: Contains the domain logic, including entities, interfaces, and services.
- **Data Layer**: Implements the repository pattern to interact with the database using ADO.NET and SQLite.
- **Unit Testing**: Uses xUnit, Moq, and FluentAssertions for unit tests for business logic and repository layers.

## Project Structure 🏗️ ⚙️

The solution is divided into multiple projects:

1. **PracticeApp.WebApi**: The Web API project (exposes HTTP endpoints).
2. **PracticeApp.Core**: The core project (contains business logic, domain entities, and interfaces).
3. **PracticeApp.Data**: The data access layer (handles database interactions using ADO.NET and SQLite).
4. **PracticeApp.UnitTests**: The unit testing project (uses xUnit, Moq, and FluentAssertions).

### Directory Structure:

```
Directory structure:
└── TayyabNazeerShaikh-PracticeApp/
    ├── README.md
    ├── PracticeApp.sln
    ├── PracticeApp.Core/
    │   ├── PracticeApp.Core.csproj
    │   ├── Entities/
    │   │   └── Product.cs
    │   ├── Interfaces/
    │   │   └── IProductRepository.cs
    │   └── Services/
    │       └── ProductService.cs
    ├── PracticeApp.Data/
    │   ├── PracticeApp.Data.csproj
    │   └── Repositories/
    │       └── ProductRepository.cs
    ├── PracticeApp.UnitTests/
    │   ├── PracticeApp.UnitTests.csproj
    │   └── Services/
    │       └── ProductServiceTests.cs
    └── PracticeApp.WebApi/
        ├── PracticeApp.WebApi.csproj
        ├── PracticeApp.WebApi.http
        ├── Program.cs
        ├── appsettings.Development.json
        ├── appsettings.json
        ├── Controllers/
        │   └── ProductController.cs
        └── Properties/
            └── launchSettings.json
```

## Design Principles & Patterns
- 1. SOLID Principles
    - `S: Single Responsibility Principle`: Each class has a single responsibility (e.g., **ProductService** for business logic, **ProductRepository** for data access).
    - `O: Open/Closed Principle`: The code is open for extension but closed for modification. You can add new services or repositories without changing existing code.
    - `L: Liskov Substitution Principle`: Subtypes can replace their base types (e.g., **IProductRepository** can have multiple implementations, like **ProductRepository**).
    - `I: Interface Segregation Principle`: The interfaces are client-specific (e.g., **IProductRepository** focuses solely on **product** operations).
    - `D: Dependency Inversion Principle`: Dependencies are injected into the service classes (e.g., **ProductService** depends on **IProductRepository**).

- 2. Repository Pattern
    - The `Repository Pattern` is used to abstract database interactions. The repository interfaces (**IProductRepository**) allow for decoupling the business logic from the data access logic.
    - The actual database interaction is implemented in the repository classes (e.g., **ProductRepository**).

- 3. Clean Architecture
    - `Separation of Concerns`: The application is split into layers to ensure clear separation between the API, core business logic, and data access logic.
    - `Dependency Injection`: Dependencies (e.g., repositories) are injected into service classes, making the code more testable and flexible.

## Packages and Dependencies
- `"Microsoft.AspNetCore.OpenApi" Version="9.0.0"`
- `"Scalar.AspNetCore" Version="1.2.74"`
- `"microsoft.data.sqlite" Version="9.0.0"`
- `"coverlet.collector" Version="6.0.2"`
- `"FluentAssertions" Version="7.0.0"`
- `"Microsoft.NET.Test.Sdk" Version="17.11.1"`
- `"Moq" Version="4.20.72"`
- `"xunit" Version="2.9.2"`
- `"xunit.runner.visualstudio" Version="2.8.2"`

## Conclusion
This project follows best practices such as Clean Architecture, SOLID principles, and Domain-Driven Design (DDD). By leveraging ADO.NET and SQLite for data access and using the Repository Pattern, the application maintains clear separation between business logic, data access, and API layers. The unit tests ensure that the application’s business logic and data access layer are thoroughly validated.

Feel free to fork or contribute to this project to extend its functionality or integrate other features such as authentication, logging, or more advanced database handling. ❤️ Thanks.
