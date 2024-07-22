using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("usuario_rol")]
    public class UserRoleIdentity
    {
        [Key]
        [Column("usuario_rol_id")]
        public int UserRoleId { get; set; }

        [Column("fk_id_usuario")]
        public int UserId { get; set; }

        [Column("fk_id_rol")]
        public int RoleId { get; set; }

        [Column("activo")]
        public bool IsActive { get; set; }
    }
}
