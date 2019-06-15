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

                x.ReceiveEndpoint(host, "request_service", e => { e.Consumer<TestConsumer>(); });
            });

            TaskUtil.Await(() => _busControl.StartAsync());

            return services;
        }



    }

}
