using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class StatusEntity : BaseEntity
    {
        public string StatusName { get; private set; }
        public StatusEntity(int id, string name)
        {
            ID = id;

            StatusName = name;
        }
        public StatusEntity()
        {

        }
    }
}
