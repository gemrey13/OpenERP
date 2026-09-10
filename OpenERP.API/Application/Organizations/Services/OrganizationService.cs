using Microsoft.EntityFrameworkCore;
using OpenERP.API.Application.Organizations.DTOs;
using OpenERP.API.Domain.Entities;
using OpenERP.API.Domain.Enum;
using OpenERP.API.Infrastructure.Persistence;

namespace OpenERP.API.Application.Organizations.Services;

public class OrganizationService(AppDbContext context) : IOrganizationService
{
    public async Task<List<OrganizationDto>> GetAllOrganizationAsync()
        => await context.Organizations
        .Select(org => new OrganizationDto
        (
            org.Id,
            org.Name,
            org.Code,
            org.ContactInformation,
            org.Status,
            org.CreatedDate
        )).ToListAsync();


    public async Task<OrganizationDto?> GetOrganizationByIdAsync(int id)
    {
        var organization = await context.Organizations
            .Where(org => org.Id == id)
            .Select(org => new OrganizationDto(
                org.Id,
                org.Name,
                org.Code,
                org.ContactInformation,
                org.Status,
                org.CreatedDate
            ))
            .FirstOrDefaultAsync();

        return organization;
    }

    public async Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organization)
    {
        var newOrg = new Organization
        {
            Name = organization.Name,
            Code = organization.Code,
            ContactInformation = organization.ContactInformation,
            Status = OrganizationStatus.Active,
            CreatedDate = DateTime.UtcNow
        };

        context.Organizations.Add(newOrg);
        await context.SaveChangesAsync();

        return new OrganizationDto(
            newOrg.Id,
            newOrg.Name,
            newOrg.Code,
            newOrg.ContactInformation,
            newOrg.Status,
            newOrg.CreatedDate
        );
    }

    public async Task<bool> UpdateOrganizationAsync(int id, UpdateOrganizationDto organization)
    {
        var existingOrganization = await context.Organizations.FirstOrDefaultAsync(org => org.Id == id);

        if (existingOrganization is null) return false;

        existingOrganization.Name = organization.Name;
        existingOrganization.ContactInformation = organization.ContactInformation;
        existingOrganization.Status = organization.Status;

        await context.SaveChangesAsync();
        return true;

    }

    public async Task<bool> DeleteOrganizationAsync(int id)
    {
        var organization = await context.Organizations.FirstOrDefaultAsync(org => org.Id == id);

        if (organization is null) return false;

        context.Organizations.Remove(organization);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeactivateOrganizationAsync(int id)
    {
        var organization = await context.Organizations.FirstOrDefaultAsync(org => org.Id == id);

        if (organization is null) return false;

        organization.Status = OrganizationStatus.Inactive;

        await context.SaveChangesAsync();
        return true;
    }
}
