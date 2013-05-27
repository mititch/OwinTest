using OwinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace OwinTest.Controllers
{
    
    public class TestController : ApiController
    {
        public int[] GetValues() {
            return new int[] { 1, 2, 3 };
        }
    }
}