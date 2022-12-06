using CommandsService.Application.Models.Commands;
using CommandsService.Application.ViewModels.Commands;
using CommandsService.Entry.WebApi.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CommandsService.Entry.WebApi.Controllers
{
    public class CommandsController : BaseController
    {
        [HttpGet("get/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CommandsGetAllVm>> GetAll([FromQuery] CommandsGetAllQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommandsGetByIdVm>> Get(int id)
        {
            var vm = await Mediator.Send(new CommandsGetByIdQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] CommandsCreateCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPost("{id:int}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new CommandsDeleteCommand { Id = id });

            return NoContent();
        }
    }
}
