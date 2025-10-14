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
             services.AddScoped<IStudentRepository,StudentRepository>();
             services.AddScoped<IStudentService,StudentService>();
        }
    }
}
