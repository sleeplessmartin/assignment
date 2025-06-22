using Microsoft.Extensions.DependencyInjection;
using Application.Checkin.Queries;
using Application.Checkin.Commands;
using System.Text.Json;
using Application.PortalUsers.Queries.Models;
using Application.PortalUsers.Queries;

namespace Application
{
    public static class DependencyInjection
    {
        public static async Task<IServiceCollection> AddApplicationAsync(this IServiceCollection services)
        {
            var portalUsers = await GetPortalUsers();
            services.AddSingleton(portalUsers);
            services.AddTransient<IGetUserDetails, GetUserDetails>();
            services.AddTransient<IGetCheckinById, GetCheckinById>();
            services.AddTransient<ICreateCheckin, CreateCheckin>();
            services.AddTransient<IUpdateCheckin, UpdateCheckin>();

            return services;
        }

        private static async Task<List<PortalUser>> GetPortalUsers()
        {
            var json = await File.ReadAllTextAsync("users.json");

            return JsonSerializer.Deserialize<List<PortalUser>>(json) ?? new List<PortalUser>();
        }
    }
}