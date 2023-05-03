using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class FactoryEntity : BaseEntity
    {
        public int CityID { get; set; }

        public string Address { get; set; }

        public int CompanyID { get; set; }

        public FactoryEntity(int iD, int cityId, string address, int compID)
        {
            ID = iD;

            CityID = cityId;

            Address = address;

            CompanyID = compID;
        }
        public FactoryEntity( int cityId, string address, int compID)
        {

            CityID = cityId;

            Address = address;

            CompanyID = compID;
        }

        public FactoryEntity()
        {

        }

    }
}
