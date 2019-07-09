using Autofac;
using DataStorage.Interfaces;
using Project.ServiceBroker.Implementations;
using Project.ServiceBroker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBroker.Implementations
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyModules(System.Reflection.Assembly.LoadFrom("..\\RefenceDLLFiles\\DataStorage.Implementations.dll"));

            //builder.RegisterType<TestImplementation>().As<TestInterface>().InstancePerLifetimeScope();
        }
    }
}
