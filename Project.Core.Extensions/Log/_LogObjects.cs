using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Extensions.Log
{
    public class LogParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }

    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
