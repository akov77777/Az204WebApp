using BusinessLogic.CQRS.GetConfigItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Az204WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigReaderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConfigReaderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetConfigSection(
            [FromQuery] string sectionName, 
            [FromQuery] bool isSection,
            CancellationToken cancellationToken)
        {
            string response = await _mediator.Send(new GetConfigItemQuery(sectionName, isSection), cancellationToken);
            return Ok(response);
        }
    }
}
