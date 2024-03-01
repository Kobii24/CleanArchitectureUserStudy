using CleanArchitectureStudy.Application.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Infrastructure.Repository.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection implementDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanDbContext>(options 
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b
                => b.MigrationsAssembly(typeof(CleanDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<ICleanDbContext>(provider
                => provider.GetService<CleanDbContext>());

            return services;
        }
    }
}
