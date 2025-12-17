using System.Web.Http;
using System.Web.Http.Cors;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Habilitar CORS
        var cors = new EnableCorsAttribute("*", "*", "*");
        config.EnableCors(cors);

        // Habilitar rutas por atributos
        config.MapHttpAttributeRoutes();

        // Ruta por defecto
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}