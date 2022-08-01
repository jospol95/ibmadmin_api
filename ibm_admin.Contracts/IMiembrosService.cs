using ibm_admin.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibm_admin.Contracts
{
    public interface IMiembrosService
    {
        Task<PaginationResultViewModel<List<MiembroViewModel>>> ObtenerMiembrosConPaginacion(int pag, int tamPag);
        Task<bool> CreateOrUpdateMiembro(
           int? id, string email, int usuarioCreacion, int idUsuarioModificacion,
           DateTime fechaBautismo, DateTime fechaConversion, DateTime fechaNacimiento,
           DateTime fechaPrimeraVezCongregado, string telefono1, string telefono2,
           string nombre, string apellido, string profesion, string direccion, string genero,
           string estadoCivil
           );
    }
}
