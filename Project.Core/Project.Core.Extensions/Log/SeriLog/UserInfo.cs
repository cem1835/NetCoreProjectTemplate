using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Extensions.Log.SeriLog
{
    public class UserInfo
    {
        public string Name { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
