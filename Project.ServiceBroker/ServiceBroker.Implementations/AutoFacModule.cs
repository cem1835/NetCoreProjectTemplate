using Autofac;
using Project.ServiceBroker.Implementations;
using Project.ServiceBroker.Interfaces;

namespace ServiceBroker.Implementations
{

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(System.Reflection.Assembly.LoadFrom("RefenceDLLFiles\\DataStorage.Implementations.dll"));

            builder.RegisterType<TestImplementation>().As<TestInterface>().InstancePerLifetimeScope();
        }
    }

}
