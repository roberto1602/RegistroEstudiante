using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public int UserRolId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int CareerId { get; set; }
        public int SubjectId { get; set; }
    }
}
