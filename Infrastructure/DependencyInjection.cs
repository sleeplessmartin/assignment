using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)       
        {
            var connectionString = configuration.GetConnectionString("AssignmentConnection");

            services.AddDbContext<AssignmentContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}