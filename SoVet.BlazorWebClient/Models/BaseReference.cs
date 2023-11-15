namespace SoVet.BlazorWebClient.Models;

public abstract class BaseReference
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}