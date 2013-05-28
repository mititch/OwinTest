using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Owin;
using System.Web.Http;
using System.Threading.Tasks;
using OwinTest.Nancy;
using OwinTest.Pipeline;

namespace OwinTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) {

            //attempt to use WebApi
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);

            //attempt to use SignalR
            app.MapHubs();

            //attempt to use Nancy
            app.UseNancy(new NancyBootstrapper());

            //attempt to use CustomMiddleware component - no work with Nancy
            app.Use(typeof(AddHeaderMiddleware));

            //attempt to use simple request handler - no work with Nancy
            app.UseHandlerAsync((req, res) =>
            {
                res.ContentType = "text/plain";
                return res.WriteAsync("Hello Word!");
            });
        }
    }
}
