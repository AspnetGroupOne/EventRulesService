using Core.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Documentation_Swagger;

public class UpdateRulesRequest_Example : IExamplesProvider<UpdateRulesRequest>
{
    public UpdateRulesRequest GetExamples() => new()
    {
        EventId = "56f58514-7581-4b18-97f5-b6eb5ba7b9c8",
        Alcohol = true,
        Bike = true,
        Camera = true,
        Hazard = true,
        Knife = true,
        Merch = true,
        Noise = true,
        Pets = true,
        Picnic = true,
        Pill = true,
        Tent = true,
        Umbrella = true
    };
}
