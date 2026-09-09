using System.ComponentModel.DataAnnotations;
using OpenERP.API.Domain.Enum;

namespace OpenERP.API.Application.Organization.DTOs;

public record OrganizationDto
(
    int Id,
    string Name,
    string Code,
    string ContactInformation,
    OrganizationStatus Status,
    DateTime CreatedDate
);