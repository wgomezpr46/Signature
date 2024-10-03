using System.Web.Http;

namespace Signature.WebAPI2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Configurar Swagger
            SwaggerConfig.Register();
        }
    }
}