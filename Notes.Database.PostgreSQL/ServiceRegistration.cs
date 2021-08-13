using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Database.PostgreSQL
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructurePostgresSql(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            
            services.AddDbContext<NotesDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("Default") 
                    // ,x => x.MigrationsAssembly("RandomYou.Database")
                ));
        }
    }
}