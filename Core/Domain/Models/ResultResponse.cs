namespace Core.Domain.Models;

public class ResultResponse
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
