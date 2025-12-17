using System;
using System.Web;
using System.Web.Http;

namespace SistemaReservas
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Configurar Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}