using Business.Career;
using Business.rol;
using Business.Student;
using Business.Students;
using Business.Subject;
using Business.UserRole;
using Data;
using Data.alunmnoRepository;
using Data.CareerRepository;
using Data.rolRepository;
using Data.StudentRepository;
using Data.Subject;
using Data.UserRoleRepostitory;
using Microsoft.EntityFrameworkCore;

namespace RegistroEstudiante
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddBusinessServices();
            services.AddDataServices();
            services.AddDataContext();
            return services;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<ICareerBusiness, CareerBusiness>();
            services.AddTransient<ISubjectBusiness, SubjectBusiness>();
            services.AddTransient<IUserRoleBusiness, UserRoleBusiness>();
            services.AddTransient<IRolBusiness, RolBusiness>();
            services.AddTransient<IStudentBusiness, StudentBusiness>();
            return services;
        }

        private static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<ICareerData, CareerData>();
            services.AddTransient<IUserData, UserData>(); 
            services.AddTransient<ISubjectData, SubjectData>(); 
            services.AddTransient<IUserRolData, UserRolData>(); 
            services.AddTransient<IRolData, RolData>();
            services.AddTransient<IStudentData, StudentData>();
            return services;
        }

        private static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services.AddDbContext<ContexMain>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DataSource") ?? "");
            });
            return services;
        }
    }
}
