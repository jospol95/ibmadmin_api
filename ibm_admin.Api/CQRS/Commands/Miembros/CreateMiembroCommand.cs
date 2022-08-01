using ibm_admin.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ibm_admin.Api.CQRS.Commands.Miembros
{
    public class CreateOrUpdateMiembroCommand : IRequest<bool>
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public int UsuarioCreacion { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaBautismo { get; set; }
        public DateTime FechaConversion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaPrimeraVezCongregado { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Profesion { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }

    }

    public class CreateOrUpdateMiembroCommandHandler : IRequestHandler<CreateOrUpdateMiembroCommand, bool>
    {
        private readonly IMiembrosService _miembrosService;

        public CreateOrUpdateMiembroCommandHandler(IMiembrosService miembroService)
        {
            _miembrosService = miembroService;
        }
        public async Task<bool> Handle(CreateOrUpdateMiembroCommand request, CancellationToken cancellationToken)
        {
            //TODO. GET MIEMBROS AFTER UPDATE
            return await _miembrosService.CreateOrUpdateMiembro
                (request.Id, request.Email, request.UsuarioCreacion, request.IdUsuarioModificacion,
                request.FechaBautismo, request.FechaConversion, request.FechaNacimiento,
                request.FechaPrimeraVezCongregado, request.Telefono1, request.Telefono2,
                request.Nombre, request.Apellido, request.Profesion, request.Direccion, request.Genero,
                request.EstadoCivil);
        }
    }
}
