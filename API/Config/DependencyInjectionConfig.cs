using Application.Services;
using Domain.Abstractions;
using Infra.Repository;

namespace API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository, ConctactRepository>();

            return services;
        }
    }
}
