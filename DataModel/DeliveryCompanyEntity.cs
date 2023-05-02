using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class DeliveryCompanyEntity : BaseEntity
    {
        public string Name { get; set; }

        public double PriceForKm { get; set; }

        public DeliveryCompanyEntity(int id, string name, double priceKm)
        {
            ID = id;

            Name = name;

            PriceForKm = priceKm;
        }

        public DeliveryCompanyEntity()
        {

        }
    }
}
