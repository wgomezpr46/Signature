using Swashbuckle.Application;
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

            // Configurar Swagger
            config.EnableSwagger(c => { c.SingleApiVersion("v1", "Signature.WebAPI2"); }).EnableSwaggerUi();
        }
    }
}