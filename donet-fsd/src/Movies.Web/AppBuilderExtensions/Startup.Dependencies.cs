

namespace Movies.Web.AppBuilderExtensions
{
 
    using Microsoft.Extensions.DependencyInjection;
    using Movies.Client.Core.Infrastructure.Abstractions.Repositories;
    using Movies.Client.Core.Infrastructure.Abstractions.Services;
    using Movies.Client.Core.ServiceAgents;
    using Movies.Client.Core.ServiceAgents.Interfaces;
    using Movies.Mapper;
    using Movies.Mapper.Interfaces;
    using Movies.Web.Infrastructure.Repositories;
    using Movies.Web.Infrastructure.Services;
    using Movies.Web.Services;
    using Movies.Web.Services.Interfaces;

    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDataRepository, ApplicationDataRepository>();
            services.AddSingleton<IApplicationSettingServiceSingleton, ApplicationSettingServiceSingleton>();
            services.AddScoped<IMovieClient, MovieClient>();
            services.AddScoped<IMovieMapper, MovieMapper>();
            services.AddScoped<IMovieService, MovieService>();
            return services;
        }
    }
}