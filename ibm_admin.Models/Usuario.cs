using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ibm_admin.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario")]
        public string NombreUsuario { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; }

        [Column("id_rol")]
        public int IdRol { get; set; }

        [Column("id_miembro")]
        public int IdMiembro { get; set; }

        [Column("estado_usuario")]
        public bool EstadoUsuario { get; set; }

        [Column("id_usuario_modificacion")]
        public int IdUsuarioModificacion { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("password_salt")]
        public string PasswordSalt { get; set; }

    }
}