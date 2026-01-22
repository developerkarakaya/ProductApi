using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Interfaces.Repositories;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;
using ProductApi.Persistence.Context;
using ProductApi.Persistence.Repositories;
using ProductApi.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Persistence
{
    public static class Registration
    {

        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


            services.AddIdentityCore<User>(options => 
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireDigit = false;
            }).AddRoles<Role>()
              .AddEntityFrameworkStores<AppDbContext>();

        }
    }
}
