
using Microsoft.AspNetCore.Builder;

namespace MyCampus.Web.AppBuilderExtensions
{
   

    public static class RouteExtensions
    {

        public static IApplicationBuilder ConfigureRoutes(this IApplicationBuilder app)
        {
            return app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Movies", action = "Index" });
            });
        }
    }
}