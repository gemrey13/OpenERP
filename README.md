# OpenERP

OpenERP is an open-source Enterprise Resource Planning (ERP) system built with ASP.NET Core and designed to provide a modular foundation for managing business operations.

The project is currently under active development. Its goal is to provide a modern, maintainable, and extensible ERP platform that can be adapted to different organizations and business requirements.

> **Status:** 🚧 Active Development

## Features

OpenERP is being developed as a modular ERP system. Current and planned modules include:

* 🏢 Organization Management
* 👥 Employee Management
* 👤 User Management
* 🔐 Authentication and Authorization
* 💰 Payroll Management
* 🏦 Bank Payment Processing
* 📊 Reporting
* 📝 Audit Trail
* 📦 Inventory Management
* 🧾 Accounting
* 🕒 Attendance Management
* 📅 Leave Management

Features may change as the project evolves.

## Technology Stack

### Backend

* ASP.NET Core
* C#
* Entity Framework Core
* SQL Server
* RESTful API

### Testing

* xUnit
* FluentAssertions
* Moq
* Entity Framework Core InMemory

### Development

* Visual Studio Code
* .NET CLI
* Git
* GitHub

## Architecture

OpenERP currently uses a modular structure within a single ASP.NET Core project.

```text
OpenERP/
│
├── OpenERP.API/
│   │
│   ├── Controllers/
│   │   ├── OrganizationsController.cs
│   │   ├── EmployeesController.cs
│   │   └── ...
│   │
│   ├── Domain/
│   │   ├── Entities/
│   │   ├── Enums/
│   │   └── Exceptions/
│   │
│   ├── Application/
│   │   ├── Organizations/
│   │   │   ├── DTOs/
│   │   │   ├── Services/
│   │   │   └── Validators/
│   │   ├── Employees/
│   │   ├── Users/
│   │   └── Common/
│   │
│   ├── Infrastructure/
│   │   ├── Persistence/
│   │   │   ├── AppDbContext.cs
│   │   │   ├── Configurations/
│   │   │   └── Repositories/
│   │   ├── Authentication/
│   │   └── ExternalServices/
│   │
│   ├── Common/
│   ├── Migrations/
│   ├── Program.cs
│   └── OpenERP.API.csproj
│
└── OpenERP.Tests/
    └── ...
```

The project follows a separation of responsibilities:

```text
Controller
    ↓
Application Service
    ↓
Repository / Infrastructure
    ↓
Entity Framework Core
    ↓
SQL Server
```

## Requirements

Before running OpenERP, install:

* [.NET SDK](https://dotnet.microsoft.com/download)
* SQL Server
* Git

Check your .NET installation:

```bash
dotnet --version
```

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/OpenERP.git
cd OpenERP
```

Replace `YOUR_USERNAME` with the repository owner's GitHub username.

### 2. Restore dependencies

```bash
dotnet restore OpenERP.API
```

### 3. Configure the database

Update:

```text
OpenERP.API/appsettings.Development.json
```

with your SQL Server connection string.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OpenERP;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Do not commit passwords, API keys, or other secrets to the repository.

### 4. Apply migrations

From the project root:

```bash
dotnet ef database update --project OpenERP.API
```

If Entity Framework CLI is not installed:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project OpenERP.API
```

The API will start using the configured ASP.NET Core environment.

## Running Tests

OpenERP uses xUnit for testing.

Run all tests:

```bash
dotnet test OpenERP.Tests
```

Run a specific test:

```bash
dotnet test OpenERP.Tests --filter "FullyQualifiedName~OrganizationServiceTests"
```

Tests should follow the:

```text
Arrange
    ↓
Act
    ↓
Assert
```

pattern.

## Development Guidelines

When adding a new module, follow the existing organization pattern:

```text
Application/
└── ModuleName/
    ├── DTOs/
    ├── Services/
    └── Validators/
```

Domain entities should be placed under:

```text
Domain/Entities/
```

EF Core configurations should be placed under:

```text
Infrastructure/Persistence/Configurations/
```

Repositories should be placed under:

```text
Infrastructure/Persistence/Repositories/
```

Controllers should be placed under:

```text
Controllers/
```

Tests should be placed under:

```text
OpenERP.Tests/
```

## Contributing

Contributions are welcome.

Before contributing, please read:

* [CONTRIBUTING.md](CONTRIBUTING.md)
* [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md)
* [SECURITY.md](SECURITY.md)

## Security

If you discover a security vulnerability, please do not create a public GitHub issue.

Read [SECURITY.md](SECURITY.md) for information about responsible disclosure.

## License

OpenERP is licensed under the MIT License.

See [LICENSE](LICENSE) for the complete license text.

## Disclaimer

OpenERP is open-source software under active development.

It may not yet be suitable for production use, particularly for systems involving payroll, accounting, financial transactions, or other legally regulated business processes.

Always review and validate the system before using it in a production environment.

## Project Goals

OpenERP aims to become:

* Modular
* Maintainable
* Secure
* Extensible
* Developer-friendly
* Community-driven
* Suitable for organizations of different sizes

Contributions, ideas, bug reports, and improvements are welcome.
