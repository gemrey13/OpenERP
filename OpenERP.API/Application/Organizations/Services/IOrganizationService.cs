using OpenERP.API.Application.Organization.DTOs;

namespace OpenERP.API.Application.Organization.Services;


public interface IOrganizationService
{
    Task<List<OrganizationDto>> GetAllOrganizationAsync();
    Task<OrganizationDto?> GetOrganizationByIdAsync(int id);
    Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organization);
    Task<bool> UpdateOrganizationAsync(int id, UpdateOrganizationDto organization);
    Task<bool> DeleteOrganizationAsync(int id);
}