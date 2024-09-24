using System.Web.Http;

namespace Signature.WebAPI2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "RootApi", routeTemplate: "", defaults: new { controller = "Default", action = "Get" });
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{action}", defaults: new { controller = "Default", action = "Get" });
        }
    }
}