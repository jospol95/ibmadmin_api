using ibm_admin.Contracts;
using ibm_admin.Shared.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ibm_admin.Api.CQRS.Queries.Miembros
{
    public class ObtenerMiembroInfoQuery: IRequest<MiembroViewModel>
    {
        int MiembroId { get; set; }

        public ObtenerMiembroInfoQuery(int id)
        {
            MiembroId = id;
        }

        public class ObtenerMiembroInfoQueryHandler : IRequestHandler<ObtenerMiembroInfoQuery, MiembroViewModel>
        {
            private readonly IMiembrosService _miembrosService;

            public ObtenerMiembroInfoQueryHandler(IMiembrosService miembrosService)
            {
                _miembrosService = miembrosService;
            }

            public async Task<MiembroViewModel> Handle(ObtenerMiembroInfoQuery request, CancellationToken cancellationToken)
            {
                return await _miembrosService.ObtenerMiembroInfo(request.MiembroId);
            }

        }

    }
}
