using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
    }
}
