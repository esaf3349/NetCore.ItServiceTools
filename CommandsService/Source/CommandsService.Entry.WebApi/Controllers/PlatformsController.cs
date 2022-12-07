using CommandsService.Entry.WebApi.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CommandsService.Application.ViewModels.Platforms;
using CommandsService.Application.Models.Platforms;
using Microsoft.AspNetCore.Http;

namespace CommandsService.Entry.WebApi.Controllers
{
    public class PlatformsController : BaseController
    {
        [HttpGet("get/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PlatformsGetAllVm>> GetAll([FromQuery] PlatformsGetAllQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] PlatformsCreateCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }
    }
}
