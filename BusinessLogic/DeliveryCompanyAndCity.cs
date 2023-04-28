using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DeliveryCompanyAndCity : BaseModel
    {

        public int CompanyID { get; set; }

        public int CityID { get; set; }

        public int AvailableCouriers { get; set; }

        public DeliveryCompanyAndCity(int id, int companyId, int cityId, int couriers)
        {
            ID = id;

            CompanyID = companyId;

            CityID = cityId;

            AvailableCouriers = couriers;
        }

        public DeliveryCompanyAndCity(int companyId, int cityId, int couriers)
        {
            CompanyID = companyId;

            CityID = cityId;

            AvailableCouriers = couriers;
        }
    }
}
