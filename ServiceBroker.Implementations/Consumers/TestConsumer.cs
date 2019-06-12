using MassTransit;
using Project.Extensions.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBroker.Implementations.Consumers
{
    public class TestConsumer : IConsumer<MessageRequest>
    {
        public async Task Consume(ConsumeContext<MessageRequest> context)
        {
            //... //......

            context.Respond(new MessageResponse(200, "test", "test"));
        }
    }
}
