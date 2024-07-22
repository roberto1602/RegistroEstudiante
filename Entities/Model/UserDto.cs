using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class UserDto
    {
        public int UserId { get; set; } 
        public string? IdentificationNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Status { get; set; }
        public string? Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
    }
}