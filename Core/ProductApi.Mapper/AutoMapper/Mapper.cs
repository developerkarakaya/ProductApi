using AutoMapper;
using AutoMapper.Internal;
using Microsoft.Extensions.Logging;

namespace ProductApi.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs =new();
        private IMapper MapperContainer;
        private ILoggerFactory iLoggerFactory;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {

            Config<TDestination,TSource>(5,ignore: ignore);
            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sourceList, string? ignore = null)
        {
            Config<TDestination, TSource>(5,ignore: ignore);

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(sourceList);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {

            Config<TDestination, object>(5, ignore: ignore);
            return MapperContainer.Map<TDestination>(source);

        }

        public IList<TDestination> Map<TDestination>(IList<object> sourceList, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore: ignore);
            return MapperContainer.Map<IList<object>,IList<TDestination>>(sourceList);
        }



        protected void Config<TDestination, TSource>(int depth=5,string? ignore = null)
        {

            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
                return;


            typePairs.Add(typePair);
            var config = new MapperConfiguration(cfg => {
                foreach (var item in typePairs)
                {

                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore,x=>x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
                }

            }, iLoggerFactory);

            MapperContainer = config.CreateMapper();
        }
    }
}
