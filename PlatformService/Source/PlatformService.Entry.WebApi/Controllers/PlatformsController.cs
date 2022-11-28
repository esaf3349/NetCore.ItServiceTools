using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PlatformService.Entry.WebApi.Controllers.Common;
using PlatformService.Application.ViewModels.Platforms;
using PlatformService.Application.Models.Platforms;
using PlatformService.Entry.WebApi.Models.Common;
using Microsoft.AspNetCore.Http;

namespace PlatformService.Entry.WebApi.Controllers
{
    public class PlatformsController : BaseController
    {
        [HttpGet("get/all")]
        public async Task<ActionResult<PlatformsGetAllVm>> GetAll([FromQuery] Page page)
        {
            var vm = await Mediator.Send(new PlatformsGetAllQuery { PageNumber = page.Number, PageSize = page.Size });

            return Ok(vm);
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlatformsGetByIdVm>> Get(int id)
        {
            var vm = await Mediator.Send(new PlatformsGetByIdQuery { Id = id });

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

        [HttpDelete("{id:int}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new PlatformsDeleteCommand { Id = id });

            return NoContent();
        }
    }
}
