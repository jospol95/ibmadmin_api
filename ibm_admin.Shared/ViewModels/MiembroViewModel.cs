using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibm_admin.Shared.ViewModels
{
    public class MiembroViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string FechaCreacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaBautismo { get; set; }
        public DateTime FechaConversion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public string Profesion { get; set; }
        public DateTime FechaCongregacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreUsuarioCreacion { get; set; }
        public string ApellidoUsuarioCreacion { get; set; }
        public string NombreUsuarioModificacion { get; set; }
        public string ApellidoUsuarioModificacion { get; set; }

        public MiembroViewModel()
        {

        }

        public MiembroViewModel(int id)
        {
            Id = id;
            Nombre = "Nombre test" + id.ToString();
            Email = "EmailTEst" + id.ToString();
            Telefono1 = "TelefonoTest";
            Telefono2 = "TelefonoTest";
            Genero = "Genero";
        }
    }


}
