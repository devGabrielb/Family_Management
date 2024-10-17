using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence.Database;

namespace Persistence
{
    public static class DependenciesInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<FamilyManagementContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")!).UseSnakeCaseNamingConvention());

            return services;
        }
    }
}