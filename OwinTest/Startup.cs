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

            
            //attempt to use WebApi
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            //attempt to use CustomMiddleware component
            app.Use(typeof(AddHeaderMiddleware));

            //attempt to use simple request handler
            app.UseHandlerAsync((req, res) =>
            {
                res.ContentType = "text/plain";
                return res.WriteAsync("Hello Word!");
            });

        }
    }
}
