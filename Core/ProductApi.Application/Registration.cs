using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Beheviors;
using ProductApi.Application.Exceptions;
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
            var assembly = Assembly.GetExecutingAssembly();
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            
            services.AddTransient<ExceptionMiddleware>();
            
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehevior<,>));




        }

         
    }
}
