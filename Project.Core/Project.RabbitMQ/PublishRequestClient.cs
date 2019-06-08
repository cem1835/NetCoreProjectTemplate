using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;

namespace Project.MQ
{
    public class PublishRequestClient
    {

        public IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri(MqAuth.HostName), h =>
            {
                h.Username(MqAuth.UserName);
                h.Password(MqAuth.Password);
            }));
        }

        public async Task<TResponse> CreateRequest<TRequest,TResponse>(TRequest request,string uriAdress)
                                                                                                    where TRequest :class where TResponse:class
        {
            var busControl = this.CreateBus();

           

            IRequestClient<TRequest, TResponse> client = busControl.CreateRequestClient<TRequest, TResponse>(new Uri(uriAdress), TimeSpan.FromSeconds(10));

            var response = await client.Request(request);

            return response;
        }
    }

   
}
