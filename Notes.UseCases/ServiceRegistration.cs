using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.UseCases
{
    public static class ServiceRegistration
    {
        public static void AddUseCases(
            this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}