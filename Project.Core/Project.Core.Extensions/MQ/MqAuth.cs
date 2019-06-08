using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Extensions.MQ
{
    public class MqAuth
    {
        public static string HostName => "rabbitmq://localhost/";
        public static string UserName => "guest";
        public static string Password => "guest";
    }
}
