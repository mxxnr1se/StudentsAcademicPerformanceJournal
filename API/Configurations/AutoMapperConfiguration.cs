using AutoMapper;
using BLL.Extensions;

namespace API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(configure =>
            {
                configure.AddProfile(new AutoMapperProfiles());
            });

            return mapperConfig.CreateMapper();
        }
    }
}