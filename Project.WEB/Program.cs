using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;

namespace Project.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host=WebHost
                            .CreateDefaultBuilder(args)
                            .ConfigureServices(services=>services.AddAutofac())
                            .UseStartup<Startup>()
                            .Build();

            host.Run();           
        }
    }
}
