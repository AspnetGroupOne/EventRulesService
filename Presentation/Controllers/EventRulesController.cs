using Core.Domain.Models;
using Core.External.Interfaces;
using Core.External.Services;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Documentation_Swagger;
using Presentation.Extensions.Attributes;
using Presentation.Factory;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Controllers;

[UseApiKey]
[Consumes("application/json")]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class EventRulesController(IForbiddenItemService forbiddenItemService, IEventValidationService eventValidationService) : ControllerBase
{
    private readonly IForbiddenItemService _forbiddenItemService = forbiddenItemService;
    private readonly IEventValidationService _eventValidation = eventValidationService;

    [HttpPost]
    [SwaggerOperation(Summary = "Adds rules for an event.")]
    [SwaggerResponse(200, "Added rules to the event.")]
    [SwaggerResponse(400, "The AddRulesRequest was either containing invalid or missing properties.")]
    [SwaggerResponse(400, "The event id given does not exist among the events created.")]
    [SwaggerRequestExample(typeof(AddRulesRequest), typeof(AddRulesRequest_Example))]
    public async Task<IActionResult> Create(AddRulesRequest addRulesRequest)
    {
        if (!ModelState.IsValid) { return BadRequest(); }

        // Only need to validate when adding data the first time.
        var validationResult = await _eventValidation.EventExistanceCheck(addRulesRequest.EventId);
        if (!validationResult.Success) { return BadRequest(); }

        var addRulesForm = FormFactory.Create(addRulesRequest);
        var result = await _forbiddenItemService.AddAForbiddenItem(addRulesForm);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Updates rules for an event.")]
    [SwaggerResponse(200, "Updated the rules of the event.")]
    [SwaggerResponse(400, "The UpdateRulesRequest was either containing invalid or missing properties.")]
    [SwaggerRequestExample(typeof(UpdateRulesRequest), typeof(UpdateRulesRequest_Example))]
    public async Task<IActionResult> Update(UpdateRulesRequest updateRulesRequest)
    {
        if (!ModelState.IsValid) { return BadRequest(); }

        var updateRulesForm = FormFactory.Create(updateRulesRequest);
        var result = await _forbiddenItemService.UpdateForbiddenItems(updateRulesForm);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets rules for an event.")]
    [SwaggerResponse(200, "Returns the rules of the event with the given id.")]
    [SwaggerResponse(400, "The id given was null.")]
    public async Task<IActionResult> GetRules(string id)
    {
        if (id == null) { return BadRequest(); }

        var result = await _forbiddenItemService.GetAForbiddenItem(id);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletes rules for an event.")]
    [SwaggerResponse(200, "Deleted the rules of the event with the given id.")]
    [SwaggerResponse(400, "The id given was null.")]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null) { return BadRequest(); }

        var result = await _forbiddenItemService.RemoveForbiddenItem(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
