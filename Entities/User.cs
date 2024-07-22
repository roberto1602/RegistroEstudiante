using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("usuario")]
    public class User
    {
        [Key]
        [Column("usuario_id")]
        public int UserId { get; set; }

        [Column("numero_identificacion")]
        public string? IdentificationNumber { get; set; }

        [Column("nombre")]
        public string? FirstName { get; set; }

        [Column("apellido")]
        public string? LastName { get; set; }

        [Column("nombre_usuario")]
        public string? Username { get; set; }

        [Column("correo")]
        public string? Email { get; set; }

        [Column("telefono")]
        public string? Phone { get; set; }

        [Column("direccion")]
        public string? Address { get; set; }

        [Column("genero")]
        public string? Gender { get; set; }

        [Column("estado")]
        public string? Status { get; set; }

        [Column("contrasena")]
        public string? Password { get; set; }

        [Column("fecharegistro")]
        public DateTime RegistrationDate { get; set; }

        [Column("activo")]
        public bool IsActive { get; set; }
    }

}