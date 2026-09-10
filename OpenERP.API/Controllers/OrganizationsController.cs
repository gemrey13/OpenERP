using Microsoft.AspNetCore.Mvc;
using OpenERP.API.Application.Organizations.DTOs;
using OpenERP.API.Application.Organizations.Services;

namespace OpenERP.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrganizationsController(IOrganizationService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OrganizationDto>>> GetAllOrganizations()
        => Ok(await service.GetAllOrganizationAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<OrganizationDto>> GetOrganizationById(int id)
    {
        var org = await service.GetOrganizationByIdAsync(id);
        return org is null ? NotFound("Organization is not found.") : Ok(org);
    }

    [HttpPost]
    public async Task<ActionResult<OrganizationDto>> CreateOrganization(CreateOrganizationDto org)
    {
        var organization = await service.CreateOrganizationAsync(org);
        return CreatedAtAction(nameof(GetOrganizationById), new { id = organization.Id }, organization);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrganization(int id, UpdateOrganizationDto organizationDto)
    {
        var updatedOrg = await service.UpdateOrganizationAsync(id, organizationDto);
        return updatedOrg ? NoContent() : NotFound("Organization is not found.");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrganization(int id)
    {
        var deletedOrg = await service.DeleteOrganizationAsync(id);
        return deletedOrg ? NoContent() : NotFound("Organization is not found.");
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> DeactivateOrganization(int id)
    {
        var deletedOrg = await service.DeactivateOrganizationAsync(id);
        return deletedOrg ? NoContent() : NotFound("Organization is not found.");
    }
}