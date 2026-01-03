using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            // Add application services here in the future
            var assembly = Assembly.GetExecutingAssembly();
            // mediatr için assembly altındaki tüm handlerları tarar ve kaydeder
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
