using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using OpenERP.API.Application.Organization.Services;
using OpenERP.API.Domain.Entities;
using OpenERP.API.Domain.Enum;
using OpenERP.API.Infrastructure.Persistence;
using OpenERP.API.Application.Organization.DTOs;

namespace OpenERP.Tests.Application;


public class OrganizationServiceTests
{
    private static async Task<AppDbContext> CreateContextAsync()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);

        context.Organizations.AddRange(
            new Organization
            {
                Id = 1,
                Name = "Company One",
                Code = "CO1",
                ContactInformation = "company1@example.com",
                Status = OrganizationStatus.Active,
                CreatedDate = new DateTime(2026, 1, 1)
            },
            new Organization
            {
                Id = 2,
                Name = "Company Two",
                Code = "CO2",
                ContactInformation = "company2@example.com",
                Status = OrganizationStatus.Active,
                CreatedDate = new DateTime(2026, 1, 2)
            },
            new Organization
            {
                Id = 3,
                Name = "Company Three",
                Code = "CO3",
                ContactInformation = "company3@example.com",
                Status = OrganizationStatus.Inactive,
                CreatedDate = new DateTime(2026, 1, 3)
            }
        );

        await context.SaveChangesAsync();

        return context;
    }

    [Fact]
    public async Task GetAllOrganizationAsync_ShouldReturnAllOrganizations()
    {
        // Arrange
        await using var context = await CreateContextAsync();
        var service = new OrganizationService(context);

        // Act
        var result = await service.GetAllOrganizationAsync();

        // Assert
        result.Should().HaveCount(3);

        result.Should().Contain(x =>
            x.Id == 1 &&
            x.Name == "Company One" &&
            x.Code == "CO1"
        );

        result.Should().Contain(x =>
            x.Id == 2 &&
            x.Name == "Company Two" &&
            x.Code == "CO2"
        );

        result.Should().Contain(x =>
            x.Id == 3 &&
            x.Name == "Company Three" &&
            x.Code == "CO3"
        );
    }

    [Fact]
    public async Task GetOrganizationByIdAsync_ShouldReturnOrganization()
    {
        // Arrange
        await using var context = await CreateContextAsync();
        var service = new OrganizationService(context);

        // Act
        var result = await service.GetOrganizationByIdAsync(1);

        // Assert
        result.Should().NotBeNull();

        result!.Id.Should().Be(1);
        result.Name.Should().Be("Company One");
        result.Code.Should().Be("CO1");
        result.ContactInformation.Should().Be("company1@example.com");
        result.Status.Should().Be(OrganizationStatus.Active);
    }

    [Fact]
    public async Task GetOrganizationByIdAsync_ShouldReturnNull_WhenOrganizationDoesNotExist()
    {
        // Arrange
        await using var context = await CreateContextAsync();
        var service = new OrganizationService(context);

        // Act
        var result = await service.GetOrganizationByIdAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateOrganizationAsync_ShouldCreateNewOrganization()
    {
        await using var context = await CreateContextAsync();
        var service = new OrganizationService(context);

        var newOrganization = new CreateOrganizationDto
        {
            Name = "Company Four",
            Code = "CO4",
            ContactInformation = "company4@example.com",
        };
        
        var result = await service.CreateOrganizationAsync(newOrganization);

        result.Should().NotBeNull();
        result.Name.Should().Be("Company Four");
        result.Code.Should().Be("CO4");
        result.ContactInformation.Should().Be("company4@example.com");
        result.Status.Should().Be(OrganizationStatus.Active);

        var organization = await context.Organizations
            .FirstOrDefaultAsync(x => x.Code == "CO4");

        organization.Should().NotBeNull();
        organization!.Name.Should().Be("Company Four");
        organization.Code.Should().Be("CO4");
    }
}