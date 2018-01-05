

namespace Movies.Api.AppBuilderExtensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Movies.Api.Data;

    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
           services.AddScoped<IMoviesRepository, MoviesRepository>();
           
            return services;
        }
    }
}