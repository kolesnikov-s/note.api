using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Notes.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}