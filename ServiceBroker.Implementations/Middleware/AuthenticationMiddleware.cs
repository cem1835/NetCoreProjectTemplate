using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBroker.Implementations.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authentication = context.Request.Headers["Authorization"];

            if (authentication != null && authentication.StartsWith("simple"))
            {
                var token = authentication.Substring(7).Trim();
                // simple username:password
                if (token.Length > 5)
                {
                    string[] res = Encoding.UTF8.GetString(Convert.FromBase64String(token)).Split(':');

                    if (res.Length == 2)
                    {

                    }
                }
            }

            await _next(context);
        }
    }
}
