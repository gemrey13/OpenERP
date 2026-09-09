using OpenERP.API.Domain.Enum;

namespace OpenERP.API.Domain.Entities;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string ContactInformation { get; set; } = string.Empty;
    public OrganizationStatus Status { get; set; } = OrganizationStatus.Active;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}