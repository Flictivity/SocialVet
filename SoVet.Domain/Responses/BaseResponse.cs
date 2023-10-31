namespace SoVet.Domain.Responses;

public class BaseResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}