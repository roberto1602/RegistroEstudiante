using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [Table("alumno")]
    public class StudentIdentity
    {
        [Key]
        [Column("alumno_id")]
        public int StudentId { get; set; }

        [Column("fk_id_usuario")]
        public int UserId { get; set; }

        [Column("fk_id_rol")]
        public int RoleId { get; set; }

        [Column("fk_carrera_id")]
        public int CareerId { get; set; }

        [Column("fk_materia_id")]
        public int SubjectId { get; set; }

        [Column("rol")]
        public string? RoleName { get; set; }

        [Column("usuario")]
        public string? UserName { get; set; }

        [Column("carrera")]
        public string? CareerName { get; set; }

        [Column("materia")]
        public string? SubjectName { get; set; }

        // Propiedades adicionales
        public User? User { get; set; }
        public Role? Role { get; set; }
        public Career? Career { get; set; }
        public SubjectIdentity? Subject { get; set; }
    }
}