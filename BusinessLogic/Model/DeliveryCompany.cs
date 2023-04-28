using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DeliveryCompany : BaseModel
    {       

        public string Name { get; set; }

        public double PriceForKm { get; set; }

        public DeliveryCompany(int id, string name, double priceKm)
        {
            ID = id;

            Name = name;

            PriceForKm = priceKm;
        }

        public DeliveryCompany(string name, double priceKm) 
        {
            Name = name;

            PriceForKm = priceKm;
        }

    }
}
