using System.ComponentModel.DataAnnotations;

namespace OpenERP.API.Application.Organizations.DTOs;


// Create Request DTO
public record CreateOrganizationDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; init; }

    [Required]
    [StringLength(20, MinimumLength = 2)]
    public required string Code { get; init; }

    [StringLength(250)]
    public string ContactInformation { get; init; } = string.Empty;
}
