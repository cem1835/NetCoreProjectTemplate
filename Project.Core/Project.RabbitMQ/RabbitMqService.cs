using RabbitMQ.Client;
using System;

namespace Project.RabbitMQ
{
    // See Documentation :  https://docs.docker.com/samples/library/rabbitmq/
    // Simple RabbitMQ Installation docker run -d --hostname my-rabbit --name some-rabbit -p 8080:15672 rabbitmq:3-management
    // for clustering :  https://www.rabbitmq.com/clustering.html
    public class RabbitMqService
    {
        private static IConnection _connection;

        private RabbitMqService()
        {

        }
        public static IConnection GetConnection()
        {
            if (_connection == null)
            {
                ConnectionFactory connectionFactory = new ConnectionFactory()
                {
                    HostName="",
                    UserName="",
                    Password=""
                };

                _connection = connectionFactory.CreateConnection();
            }
            return _connection;
        }
    }
}
