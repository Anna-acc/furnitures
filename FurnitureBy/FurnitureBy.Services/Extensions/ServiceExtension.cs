using FurnitureBy.Data.Interfaces;
using FurnitureBy.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace FurnitureBy.Services.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddBaseServiceCollection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
