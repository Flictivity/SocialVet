namespace SoVet.Domain.Models;

public sealed class EmployeeReport
{
    public string EmployeeName { get; set; } = null!;
    public int FacilitiesSell { get; set; }
    public decimal FacilitiesSellSum { get; set; }
    public List<DataItem> Facilities { get; set; } = null!;
}