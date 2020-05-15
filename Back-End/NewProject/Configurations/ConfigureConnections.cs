using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDbContext<ShopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CafeV8"),
                b => b.MigrationsAssembly("Shop.API")));



            return services;
        }
    }
}
