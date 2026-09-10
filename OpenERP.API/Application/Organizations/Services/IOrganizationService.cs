using OpenERP.API.Application.Organizations.DTOs;

namespace OpenERP.API.Application.Organizations.Services;


public interface IOrganizationService
{
    Task<List<OrganizationDto>> GetAllOrganizationAsync();
    Task<OrganizationDto?> GetOrganizationByIdAsync(int id);
    Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organization);
    Task<bool> UpdateOrganizationAsync(int id, UpdateOrganizationDto organization);
    Task<bool> DeleteOrganizationAsync(int id);
    Task<bool> DeactivateOrganizationAsync(int id);
}
