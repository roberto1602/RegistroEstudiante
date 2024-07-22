using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
   [Table("carrera")]
    public class Career
    {
        [Key]
        [Column("carrera_id")]
        public int CareerId { get; set; }

        [Column("nombre")]
        public string? Name { get; set; }
    }
}