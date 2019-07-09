using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Security.Implementations.AuthenticationMiddleware
{
    public class AuthMiddleware
    {
        RequestDelegate _next;


        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //context.Response.StatusCode = 401;
            await _next.Invoke(context);
        }
    }

}
