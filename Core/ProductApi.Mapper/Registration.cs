using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Interfaces.AutoMapper;

namespace ProductApi.Persistence
{
    public static class Registration
    {

        public static void AddCustomMapper(this IServiceCollection services)
        {
           services.AddSingleton<IMapper, Mapper.AutoMapper.Mapper>();
        }
    }
}
