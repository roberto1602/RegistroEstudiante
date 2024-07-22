using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("rol")]
    public class Role
    {
        [Key]
        [Column("rol_id")]
        public int RoleId { get; set; }

        [Column("nombre")]
        public string? Name { get; set; }
    }
}
