using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Status
    {
        public string StatusName { get; private set; }

        public Status(string name) 
        {
            StatusName = name;
        }
    }
}
