using Core.Domain.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Factory;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRulesController(IForbiddenItemService forbiddenItemService) : ControllerBase
    {
        private readonly IForbiddenItemService _forbiddenItemService = forbiddenItemService;

        [HttpPost]
        public async Task<IActionResult> AddRules(AddRulesRequest addRulesRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var addRulesForm = FormFactory.Create(addRulesRequest);
            var result = await _forbiddenItemService.AddAForbiddenItem(addRulesForm);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRules(UpdateRulesRequest updateRulesRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var updateRulesForm = FormFactory.Create(updateRulesRequest);
            var result = await _forbiddenItemService.UpdateForbiddenItems(updateRulesForm);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("/id")]
        public async Task<IActionResult> GetAllRules(string id)
        {
            var result = await _forbiddenItemService.GetAllForbiddenItemsById(id);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("/id")]
        public async Task<IActionResult> RemoveRules(string id)
        {
            var result = await _forbiddenItemService.RemoveForbiddenItems(id);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
