using ibm_admin.Contracts;
using ibm_admin.Models;
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
        public int? UsuarioCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public int? MinisterioSirveId { get; set; }
        public int? MinisterioMiembroId { get; set; }
        public DateTime? FechaBautismo { get; set; }
        public DateTime? FechaConversion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaPrimeraVezCongregado { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Profesion { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public int DepartamentoId { get; set; }

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
            var miembro = new Miembro()
            {
                Id = request.Id,
                Email = request.Email,
                Apellido = request.Apellido,
                Telefono1 = request.Telefono1,
                Telefono2 = request.Telefono2,
                MinisterioMiembroId = request.MinisterioMiembroId,
                MinisterioSirveId = request.MinisterioSirveId,
                Genero = request.Genero,
                DepartamentoId = request.DepartamentoId,
                FechaBautismo = request.FechaBautismo,
                FechaConversion = request.FechaConversion,
                FechaNacimiento = request.FechaNacimiento,
                FechaPrimeraVezCongregado = request.FechaPrimeraVezCongregado,
                Direccion = request.Direccion,
                Profesion = request.Profesion,
                EstadoCivil = request.EstadoCivil
            };

            return await _miembrosService.CreateOrUpdateMiembro(miembro);
        }
    }
}
