using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Project.Extensions.Log.SeriLog;

namespace ServiceBroker.Implementations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loggerConfiguration = new ConfigurationBuilder()
                                          .SetBasePath(Directory.GetCurrentDirectory())
                                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                          .AddEnvironmentVariables()
                                          .Build();

            IWebHost host = WebHost.CreateDefaultBuilder(args)
                                   .UseSerilog((provider, context, loggerConfig) => { loggerConfig.WithSimpleConfiguration(provider, "ServiceBroker.Implementations", loggerConfiguration); })
                                   .UseStartup<Startup>()
                                   .Build();

            host.Run();
        }
    }
}
