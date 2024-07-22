using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("materia")]
    public class SubjectIdentity
    {
        [Key]
        [Column("materia_id")]
        public int SubjectId { get; set; }

        [Column("nombre")]
        public string? Name { get; set; }

        [Column("credito_materia")]
        public double Credit { get; set; }

        [Column("fk_carrera_id")]
        public int CareerId { get; set; }
    }
}