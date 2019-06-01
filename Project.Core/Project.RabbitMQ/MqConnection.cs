using RabbitMQ.Client;
using System;

namespace Project.RabbitMQ
{
    // See Documentation :  https://docs.docker.com/samples/library/rabbitmq/
    // Simple RabbitMQ Installation docker run -d --hostname my-rabbit --name some-rabbit -p 8080:15672 rabbitmq:3-management
    // for clustering :  https://www.rabbitmq.com/clustering.html
    public class MqConnection
    {
        private static IConnection _connection;

        private MqConnection()
        {

        }
        public static IConnection GetConnection()
        {
            if (_connection == null)
            {
                ConnectionFactory connectionFactory = new ConnectionFactory()
                {
                    HostName="localhost:7979",
                    UserName="guest",
                    Password="guest"
                };

                _connection = connectionFactory.CreateConnection();
            }
            //_connection.
            return _connection;
        }
    }
}
