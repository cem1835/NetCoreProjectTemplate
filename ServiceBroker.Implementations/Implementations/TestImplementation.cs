using DataStorage.Interfaces;
using Project.ServiceBroker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServiceBroker.Implementations
{
    public class TestImplementation : TestInterface
    {
        private ISampleEntityDAL _sampleEntityDAL;

        public TestImplementation(ISampleEntityDAL sampleEntityDAL)
        {
            _sampleEntityDAL = sampleEntityDAL;
        }

        public string GetTestString()
        {
            return _sampleEntityDAL.TestDAL();
        }
    }
}
