using RabbitMQ.Client;
using System;

namespace Project.RabbitMQ
{
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
