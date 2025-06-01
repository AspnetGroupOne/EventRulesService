namespace Core.External.Models;

public class ExternalApiOptions
{
    // This way of getting the Url from the appsettings file is from chatgpt.
    public string EventApiBaseUrl { get; set; } = null!;
}
