using Owin;
using System.Web.Http;
using System.Web.Http.Cors;


namespace OwinSelfHostSample
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        

        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.EnableCors(new EnableCorsAttribute(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
            SwaggerConfig.Register(config);
            appBuilder.UseWebApi(config);
        }
        

    }
}
