using Core.Domain.Models;
using Core.Factories;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var addRule = RuleFactory.Create(addRulesRequest);


            //Do a state check. 
            //Could split it here and send it seperately to the services?
            //If doing that then i need to send the entity first to get the id.
            // and then send the list and the id on to the item service.

        }

        [HttpPut]
        public async Task<IActionResult> UpdateRules(UpdateRulesRequest updateRulesRequest)
        {
            //statecheck
            //need to get the entity with the guid id and add the id to the form and send it on.
            // turn request into update. If rule not in the new list then remove.
        }

        [HttpGet("/id")]
        public async Task<IActionResult> GetAllRules(string id)
        {
            //find which entity and then get all of the other entities with the same id


        }

        [HttpDelete("/id")]
        public async Task<IActionResult> RemoveRules()
        {
            //Find the entity and which id. Remove it all.
        }
    }
}
