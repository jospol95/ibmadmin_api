using ibm_admin.Api.CQRS.Commands.Miembros;
using ibm_admin.Api.CQRS.Queries.Miembros;
using ibm_admin.Server.CQRS.Queries.Miembros;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ibm_admin.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembrosController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;


        public MiembrosController(IMediator mediator, ILogger<MiembrosController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        //[HttpGet("Get/{pagActual}/{tamPagina}")]
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAll(int pagActual, int tamPagina)
        {
            _logger.LogInformation("MiembrosAPI -> GetAll los miembros fue ejecutado. {DT}", DateTime.UtcNow.ToLongTimeString());
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

        //[HttpGet("Get")]
        [HttpGet] //probably remove this
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("MiembrosAPI -> Obtener miembro con Id = . {DT}", DateTime.UtcNow.ToLongTimeString());

            var request = new ObtenerMiembroInfoQuery(id);
            var miembroDetails = await _mediator.Send(request);
            if(miembroDetails == null)
            {
                _logger.LogWarning($"MiembrosAPI -> Miembro con Id = {id} no fue encontrado ");
                return NotFound();
            }
            return Ok(miembroDetails);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateOrUpdateMiembroCommand miembro)
        {
             _logger.LogInformation("MiembrosAPI -> Crear miembro. {DT}", DateTime.UtcNow.ToLongTimeString());
            var miembroAddedOrUpdated = await _mediator.Send(miembro);
            if (miembroAddedOrUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
