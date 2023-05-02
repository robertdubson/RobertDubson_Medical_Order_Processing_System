using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class DeliveryCompanyAndCityEntity : BaseEntity
    {
        public int CompanyID { get; set; }

        public int CityID { get; set; }

        public int AvailableCouriers { get; set; }

        public DeliveryCompanyAndCityEntity(int id, int companyId, int cityId, int couriers)
        {
            ID = id;

            CompanyID = companyId;

            CityID = cityId;

            AvailableCouriers = couriers;
        }

        public DeliveryCompanyAndCityEntity()
        {

        }
    }
}
