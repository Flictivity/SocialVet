namespace SoVet.Domain.Models;

public class FacilityReport
{
    public string FacilityName { get; set; } = null!;
    public string FacilityCategoryName { get; set; } = null!;
    public string FacilityCost { get; set; } = null!;
    public int UseCount { get; set; }
    public int Sum { get; set; }
}