using System;
using Autofac;
using DataStorage.Interfaces;

namespace DataStorage.Implementations
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleEntityDAL>().As<ISampleEntityDAL>().InstancePerLifetimeScope();
        }
    }
}
