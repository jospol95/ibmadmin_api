using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibm_admin.Models
{
    public class Miembro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
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


    }
}
