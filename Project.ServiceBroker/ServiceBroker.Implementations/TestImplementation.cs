using System;
using Project.ServiceBroker.Interfaces;

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