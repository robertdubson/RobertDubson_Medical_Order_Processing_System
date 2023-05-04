using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models
{
    public class SupplierViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string StrId { get; set; }
        public SupplierViewModel(int Id, string name)
        {
            ID = Id;

            StrId = Id.ToString();

            Name = name;
        }

    }
}
