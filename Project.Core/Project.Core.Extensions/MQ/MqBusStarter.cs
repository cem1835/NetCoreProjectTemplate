using MassTransit;
using MassTransit.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Extensions.MQ
{
   public static class MqBus
    {
        private static IBusControl _busControl;

        public static IBusControl GetBus()
        {
            if (_busControl == null)
            {
                _busControl= Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri(MqAuth.HostName), h =>
                {
                    h.Username(MqAuth.UserName);
                    h.Password(MqAuth.Password);
                }));
                
                TaskUtil.Await(() => _busControl.StartAsync());
            }

            return _busControl;
        }


        public static async Task<TResponse> CreateRequest<TRequest, TResponse>(TRequest request)
                                                                                                    where TRequest : class where TResponse : class
        {
            var uriAdress = new Uri(MqAuth.HostName + request.GetType().Name);
            IRequestClient<TRequest, TResponse> client = GetBus().CreateRequestClient<TRequest, TResponse>(uriAdress, TimeSpan.FromSeconds(10));

            //IRequestClient<TRequest, TResponse> client = GetBus().CreatePublishRequestClient<TRequest, TResponse>(TimeSpan.FromSeconds(10),TimeSpan.FromSeconds(5));

            var response = await client.Request(request);

            return response;
        }

    }
}
