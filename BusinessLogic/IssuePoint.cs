using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class IssuePoint
    {

        public int ID { get; private set; }

        public City Location { get; set; }

        public string Address { get; set; }
    }
}
