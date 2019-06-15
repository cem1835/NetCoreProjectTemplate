using Microsoft.AspNetCore.Http;
using System;

namespace Security.Implementations
{
    public static class JWTExtensions
    {
        public static void ApplicationError(this HttpResponse httpResponse,string errorMessage)
        {
            httpResponse.Headers.Add("Application-Error", errorMessage);
            httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            httpResponse.Headers.Add("Access-Control-Expose-Header", "Application-Error");
        }
    }
}
