using ibm_admin.Shared.ViewModels;
using IBM_Yoda_Admin.CQRS.Queries.Menu;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ibm_admin.Server.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var request = new ObternerItemsMenuQuery(1);
                var menuItems = await _mediator.Send(request);
                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
