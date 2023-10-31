namespace SoVet.BlazorWebClient.Results;

public sealed class BaseResult
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}