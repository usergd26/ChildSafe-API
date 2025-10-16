using ChildSafe.Application.Interfaces;
using ChildSafe.Application.Services;
using ChildSafe.Domain.Interfaces;
using ChildSafe.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChildSafe.Infrastructure.DIContainer
{
    public static class DIContainer
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<ISchoolService,SchoolService>();


            //Repositories
            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<ISchoolRepository,SchoolRepository>();
        }
    }
}
