using System.ComponentModel.DataAnnotations;
using OpenERP.API.Domain.Enum;

namespace OpenERP.API.Application.Organizations.DTOs;

// Update Request DTO
public record UpdateOrganizationDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; init; }

    [StringLength(250)]
    public string ContactInformation { get; init; } = string.Empty;

    public OrganizationStatus Status { get; init; }
}