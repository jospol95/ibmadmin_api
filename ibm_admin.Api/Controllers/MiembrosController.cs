using ibm_admin.Api.CQRS.Commands.Miembros;
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
        //[HttpGet("Get/{pagActual}/{tamPagina}")]
        [HttpGet]
        public async Task<IActionResult> Get(int pagActual, int tamPagina)
        {
            try
            {
                var request = new ObtenerMiembrosConPaginacionQuery(pagActual, tamPagina);
                var miembros = await _mediator.Send(request);
                return Ok(miembros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrUpdateMiembroCommand miembro)
        {
            try
            {
                var miembroAddedOrUpdated = await _mediator.Send(miembro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
