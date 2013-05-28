using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace OwinTest.Nancy
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/index"] = x =>
            {
                dynamic viewBag = new DynamicDictionary();
                viewBag.WelcomeMessage = "Welcome to Nancy!";
                return View["index", viewBag];
            };
        }
    }
}