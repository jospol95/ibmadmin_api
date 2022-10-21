using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ibm_admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownDataComponent : ControllerBase
    {
        private IMediator _mediator;
        private ILogger<DropdownDataComponent> _logger;

        public DropdownDataComponent(IMediator mediator, ILogger<DropdownDataComponent> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[HttpGet("sexos")]
        //public async Task<IActionResult> GetSexos()
        //{
        //    try
        //    {
        //        var request = new ObternerItemsMenuQuery(1);
        //        var menuItems = await _mediator.Send(request);
        //        return Ok(menuItems);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        //[HttpGet("ministerios")]
        //public async Task<IActionResult> GetMinisterios()
        //{
        //    try
        //    {
        //        var request = new ObternerItemsMenuQuery(1);
        //        var menuItems = await _mediator.Send(request);
        //        return Ok(menuItems);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}
    }
}
