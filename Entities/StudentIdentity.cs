using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("alumno")]
    public class StudentIdentity
    {
        [Key]
        [Column("alunmno_id")]
        public int StudentId { get; set; }

        [Column("fk_usuario_rol_id")]
        public int UserRolId { get; set; }

        [Column("fk_id_usuario")]
        public int UserId { get; set; }

        [Column("fk_id_rol")]
        public int RoleId { get; set; }

        [Column("fk_carrera_id")]
        public int CareerId { get; set; }

        [Column("fk_materia_id")]
        public int SubjectId { get; set; }
    }
}
