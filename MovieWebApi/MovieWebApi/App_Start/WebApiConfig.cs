using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieWebApi
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            //ENABLE FOR ENTIRE SITE
            var corsSettings = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsSettings);

            //ENABLE, BUT HAVE TO SWITCH ON IN CONTROLLER
            // config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}