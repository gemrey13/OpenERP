using OpenERP.API.Domain.Enum;

namespace OpenERP.API.Application.Organizations.DTOs;

public record OrganizationDto
(
    int Id,
    string Name,
    string Code,
    string ContactInformation,
    OrganizationStatus Status,
    DateTime CreatedDate
);
