using ibm_admin.Server.CQRS.Queries.Miembros;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ibm_admin.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembrosController : Controller
    {
        private readonly IMediator _mediator;

        public MiembrosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get/{pagActual}/{tamPagina}")]
        public async Task<IActionResult> Get(int pagActual, int tamPagina)
        {
            try
            {
                var request = new ObtenerMiembrosConPaginacionQuery(pagActual, tamPagina);
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
