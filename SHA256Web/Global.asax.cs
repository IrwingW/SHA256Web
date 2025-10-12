using System;
using System.Web;
using System.Web.Http;

namespace SHA256Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Spustí se při startu aplikace (např. po publikaci nebo při prvním požadavku)
            GlobalConfiguration.Configure(RegisterApiRoutes);
        }

        private void RegisterApiRoutes(HttpConfiguration config)
        {
            // Aktivuje Web API směrování pomocí atributů [Route(...)]
            config.MapHttpAttributeRoutes();
        }
    }
}
