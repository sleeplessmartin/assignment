using Microsoft.Extensions.DependencyInjection;
using Application.Checkin.Queries;
using Application.Checkin.Commands;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IGetCheckinById, GetCheckinById>();
            services.AddTransient<ICreateCheckin, CreateCheckin>();
            services.AddTransient<IUpdateCheckin, UpdateCheckin>();
            
            return services;
        }
    }
}