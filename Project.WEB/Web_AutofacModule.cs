using Autofac;

namespace Project.WEB
{
    public class AutofacModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(System.Reflection.Assembly.LoadFrom("..\\RefenceDLLFiles\\ServiceBroker.Implementations.dll"));
            
        }
    }
}
