using Core.Domain.Models;
using Core.External.Interfaces;
using Core.External.Services;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions.Attributes;
using Presentation.Factory;

namespace Presentation.Controllers;

[UseApiKey]
[Route("api/[controller]")]
[ApiController]
public class EventRulesController(IForbiddenItemService forbiddenItemService, EventValidationService eventValidationService) : ControllerBase
{
    private readonly IForbiddenItemService _forbiddenItemService = forbiddenItemService;
    private readonly IEventValidationService _eventValidation = eventValidationService;

    [HttpPost]
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
    public async Task<IActionResult> Update(UpdateRulesRequest updateRulesRequest)
    {
        if (!ModelState.IsValid) { return BadRequest(); }

        var updateRulesForm = FormFactory.Create(updateRulesRequest);
        var result = await _forbiddenItemService.UpdateForbiddenItems(updateRulesForm);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRules(string id)
    {
        if (id == null) { return BadRequest(); }

        var result = await _forbiddenItemService.GetAForbiddenItem(id);
        return result.Success ? Ok(result.Content) : BadRequest(result.Content);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null) { return BadRequest(); }

        var result = await _forbiddenItemService.RemoveForbiddenItem(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
