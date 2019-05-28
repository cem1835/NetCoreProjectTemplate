using Project.ServiceBroker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServiceBroker.Implementations
{
    public class TestImplementation : TestInterface
    {
        public string GetTestString()
        {
            return "Hello From ServiceBroker ! ";
        }
    }
}
