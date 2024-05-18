namespace SoVet.Domain.Models;

public sealed class FacilityReportResult
{
    public string EmployeeName { get; set; } = null!;
    public int FacilitiesSell { get; set; }
    public decimal FacilitiesSellSum { get; set; }
    public string FacilityName { get; set; } = null!;
    public int FacilityCount { get; set; }
}