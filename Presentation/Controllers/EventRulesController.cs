using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRulesController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> AddRules(RulesRequest rulesform)
        {



        }

        [HttpGet]






    }
}
