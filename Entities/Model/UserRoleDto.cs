using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}