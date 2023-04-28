using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class SupplierEntity : BaseEntity 
    {
        public string Name { get; set; }

        public SupplierEntity(int id, string name)
        {
            ID = id;

            Name = name;
        }
    }
}
