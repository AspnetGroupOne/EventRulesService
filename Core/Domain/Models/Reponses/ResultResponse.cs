namespace Core.Domain.Models.Reponses;

public class ResultResponse
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
