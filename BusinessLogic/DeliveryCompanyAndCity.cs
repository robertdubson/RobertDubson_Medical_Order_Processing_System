using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DeliveryCompanyAndCity
    {
        public int ID { get; private set; }

        public int CompanyID { get; set; }

        public int CityID { get; set; }

        public int AvailableCouriers { get; set; }
    }
}
