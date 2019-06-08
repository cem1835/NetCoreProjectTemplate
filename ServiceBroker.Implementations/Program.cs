using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;

namespace ServiceBroker.Implementations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = WebHost.CreateDefaultBuilder(args)
                                  .UseStartup<Startup>()
                                  .Build();

            host.Run();
        }


    }
}
