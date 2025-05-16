using Core.External.Interfaces;
using Core.External.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Core.External.Services;

public class EventValidationService : IEventValidationService
{
    // Service made together with chatgpt to fit my use.
    // Will make a get request to the starting event-api and check all of them if the eventId exists seeing as there is no get by id controller.
    private readonly HttpClient _httpClient;
    private readonly string _eventCheckingApiUrl;

    public EventValidationService(HttpClient httpClient, IOptions<ExternalApiOptions> options)
    {
        _httpClient = httpClient;
        _eventCheckingApiUrl = options.Value.EventApiBaseUrl;
    }

    public async Task<ExternalResponse> EventExistanceCheck(string eventId)
    {
        //Need to fix the url.
        var response = await _httpClient.GetAsync($"{_eventCheckingApiUrl}/events");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        // Deserializes the content into a list of DTOs and the propertynamecaseinsensitive
        // makes it so that it doesn't matter what case format the object keys comes in,
        // it will still map onto the one that I set in my externaleventDTO.
        var events = JsonSerializer.Deserialize<List<ExternalEventDTO>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (events == null) { return new ExternalResponse() { StatusCode = 400, Message = "No events found in external api.", Success = false }; }

        if (!events.Any(e => e.Id.ToString() == eventId))
        {
            return new ExternalResponse() { StatusCode = 404, Message = "Event doesn't exist in external api.", Success = false };
        }

        return new ExternalResponse() { StatusCode = 200, Success = true, Message = "Event found in external api." };
    }
}

