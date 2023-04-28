using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Status : BaseModel
    {

        public string StatusName { get; private set; }

        public Status(string name) 
        {
            StatusName = name;
        }

        public Status(int id, string name)
        {
            ID = id;

            StatusName = name;
        }
    }
}
