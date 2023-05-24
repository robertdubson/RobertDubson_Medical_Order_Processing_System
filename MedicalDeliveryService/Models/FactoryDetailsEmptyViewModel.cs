using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models
{
    public class FactoryDetailsEmptyViewModel
    {
        public int FactoryID { get; set; }

        public FactoryDetailsEmptyViewModel(int Id)
        {
            FactoryID = Id;
        }
    }
}
