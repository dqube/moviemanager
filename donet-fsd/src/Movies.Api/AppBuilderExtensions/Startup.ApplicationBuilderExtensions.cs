using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Data;
using Movies.Constants;
using Movies.Model;
using System;
using System.Threading.Tasks;

namespace Movies.Api.AppBuilderExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MoviesContext>();
                DbInitializer.Initialize(context);

            }

            return app;
        }
    }
}
