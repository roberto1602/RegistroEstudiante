using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ContexMain(DbContextOptions<ContexMain> options): DbContext(options)
    {
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<SubjectIdentity> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoleIdentity> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StudentIdentity> Students{ get; set; }
    }
}