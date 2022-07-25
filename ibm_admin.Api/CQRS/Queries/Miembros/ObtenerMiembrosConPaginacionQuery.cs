using ibm_admin.Contracts;
using ibm_admin.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ibm_admin.Server.CQRS.Queries.Miembros
{
    public class ObtenerMiembrosConPaginacionQuery : IRequest<PaginationResultViewModel<List<MiembroViewModel>>>
    {
        public int PaginaActual { get; set; }
        public int TamanioPagina { get; set; }

        public ObtenerMiembrosConPaginacionQuery(int pagActual, int tamanioPag)
        {
            PaginaActual = pagActual;
            TamanioPagina = tamanioPag;
        }
        public class ObtenerMiembrosConPaginacionQueryHandler : IRequestHandler<ObtenerMiembrosConPaginacionQuery, PaginationResultViewModel<List<MiembroViewModel>>>
        {
            private readonly IMiembrosService _miembrosService;
            public ObtenerMiembrosConPaginacionQueryHandler(IMiembrosService miembrosService)
            {
                _miembrosService = miembrosService;

            }

            public async Task<PaginationResultViewModel<List<MiembroViewModel>>> Handle(ObtenerMiembrosConPaginacionQuery request, CancellationToken cancellationToken)
            {
                return await _miembrosService.ObtenerMiembrosConPaginacion(request.PaginaActual, request.TamanioPagina);
            }

        }
    }
}
