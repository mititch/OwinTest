using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Web.Http;
using System.Threading.Tasks;
using OwinTest.Pipeline;

namespace OwinTest
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder app) {

            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            app.Use(typeof(AddHeaderMiddleware));

            app.UseHandlerAsync((req, res) =>
            {
                res.ContentType = "text/plain";
                return res.WriteAsync("Hello Word!");
            });

        }
    }
}