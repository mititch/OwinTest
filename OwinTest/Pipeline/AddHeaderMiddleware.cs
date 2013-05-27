using Owin.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinTest.Pipeline
{
    public class AddHeaderMiddleware
    {
        private Func<IDictionary<string, object>, Task> _next;

        public AddHeaderMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = new OwinResponse(environment);

            response.Headers.Add("addedHeader", new string[]{"someValue"});

            return _next(environment);
        }

    }
}