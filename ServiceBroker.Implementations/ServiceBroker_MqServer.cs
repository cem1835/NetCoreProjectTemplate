using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using ServiceBroker.Implementations.Consumers;
using MassTransit.Util;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;
using MassTransit.Configuration;

namespace ServiceBroker.Implementations
{
    public static class MqServer
    {
        static IBusControl _busControl;


        public static IServiceCollection AddMassTransit(this IServiceCollection services)
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                IRabbitMqHost host = x.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                x.ReceiveEndpoint(host, "request_service", e =>
                {
                    IReceiveEndpointConfigurator xxxx = e;

                    var assembly = typeof(ConsumerExtensions).Assembly;
                    var methods = GetExtensionMethods(assembly, typeof(IReceiveEndpointConfigurator));

                    e.Consumer<TestConsumer>();

                });
            });

            TaskUtil.Await(() => _busControl.StartAsync());

            return services;
        }


        private static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,Type extendedType)
        {
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method;
            return query;
        }



    }

}
