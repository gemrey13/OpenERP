# Contributing to OpenERP

Thank you for your interest in contributing to OpenERP.

OpenERP is an open-source project, and contributions from developers, testers, designers, documentation writers, and other members of the community are welcome.

## Before You Start

Please read:

* [README.md](README.md)
* [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md)
* [SECURITY.md](SECURITY.md)

By contributing to this project, you agree to follow the project's Code of Conduct.

## Ways to Contribute

You can contribute by:

* Fixing bugs
* Adding features
* Improving existing features
* Writing tests
* Improving documentation
* Improving security
* Improving performance
* Refactoring code
* Reporting bugs
* Suggesting new features
* Reviewing pull requests

## Development Setup

### Requirements

You will need:

* .NET SDK
* SQL Server
* Git
* A code editor or IDE

Visual Studio Code is recommended but not required.

### Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/OpenERP.git
cd OpenERP
```

### Restore Dependencies

```bash
dotnet restore OpenERP.API
dotnet restore OpenERP.Tests
```

### Build the Project

```bash
dotnet build OpenERP.API
```

### Run Tests

```bash
dotnet test OpenERP.Tests
```

Make sure existing tests pass before submitting a pull request.

## Project Structure

OpenERP currently uses a modular structure inside the `OpenERP.API` project.

```text
OpenERP.API/
├── Controllers/
├── Domain/
├── Application/
├── Infrastructure/
├── Common/
└── Migrations/
```

Tests are maintained separately:

```text
OpenERP.Tests/
```

## Creating a New Feature

When adding a new business module, follow the existing project organization.

For example:

```text
Application/
└── Employees/
    ├── DTOs/
    ├── Services/
    └── Validators/
```

Domain-specific entities should be placed under:

```text
Domain/Entities/
```

Database configurations should be placed under:

```text
Infrastructure/Persistence/Configurations/
```

## Testing

New functionality should include appropriate tests.

For example, a service should have tests covering:

* Successful operations
* Invalid input
* Missing records
* Duplicate records
* Business rules
* Expected exceptions
* Edge cases

Use:

* **xUnit** for test execution
* **FluentAssertions** for assertions
* **Moq** for mocking dependencies where appropriate
* **EF Core testing providers** for database-related tests

Tests should follow:

```text
Arrange
Act
Assert
```

## Code Style

Please keep code consistent with the existing project.

### Naming

Use descriptive names.

```csharp
GetOrganizationByIdAsync
CreateOrganizationAsync
UpdateOrganizationAsync
DeleteOrganizationAsync
```

Test names should clearly describe the behavior being tested:

```csharp
GetOrganizationByIdAsync_ShouldReturnOrganization()

GetOrganizationByIdAsync_ShouldReturnNull_WhenOrganizationDoesNotExist()

CreateOrganizationAsync_ShouldCreateNewOrganization()
```

### Async Methods

Use asynchronous APIs for database and I/O operations.

```csharp
public async Task<OrganizationDto?> GetOrganizationByIdAsync(int id)
{
    // ...
}
```

Avoid blocking asynchronous operations with:

```csharp
.Result
.Wait()
```

## Commits

Use clear and descriptive commit messages.

Good examples:

```text
feat: add organization creation
feat: add employee management
fix: prevent duplicate organization codes
test: add organization service tests
refactor: simplify organization repository
docs: update installation instructions
```

Avoid vague messages such as:

```text
update
changes
fix
stuff
```

## Branches

Create a branch for your work.

Examples:

```bash
git checkout -b feature/organization-management
```

```bash
git checkout -b fix/duplicate-organization-code
```

```bash
git checkout -b test/organization-service
```

## Pull Requests

Before opening a pull request:

1. Make sure the project builds.
2. Run the test suite.
3. Review your changes.
4. Remove debugging code.
5. Update documentation when necessary.
6. Provide a clear pull request description.

A pull request should explain:

* What was changed
* Why it was changed
* How it was tested
* Any limitations or known issues

## Issues

When reporting a bug, include:

* A clear description
* Steps to reproduce
* Expected behavior
* Actual behavior
* Relevant error messages
* Environment information

Do not publicly disclose security vulnerabilities through normal issues.

See [SECURITY.md](SECURITY.md) for security reports.

## Code Review

Pull requests may be reviewed for:

* Correctness
* Security
* Maintainability
* Performance
* Testing
* Project architecture
* Code quality

Be respectful during code review and focus on improving the project.

## License

By contributing to OpenERP, you agree that your contributions will be licensed under the project's MIT License.
