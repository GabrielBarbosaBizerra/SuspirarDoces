using Microsoft.Extensions.DependencyInjection;
using SuspirarDoces.Application.Mappings;
using System;

namespace SuspirarDoces.API.ConfigurationMapping
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModel),
                typeof(ViewModelToDomain));
        }
    }
}
