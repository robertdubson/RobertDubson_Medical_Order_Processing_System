using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Factory : BaseModel
    {

        public int CityID { get; set; }

        public string Address { get; set; }

        public int CompanyID { get; set; }

        public Factory(int iD, int cityId, string address, int compID)
        {
            ID = iD;

            CityID = cityId;

            Address = address;

            CompanyID = compID;
        }

        public Factory(int cityId, string address, int compID)
        {
            CityID = cityId;

            Address = address;

            CompanyID = compID;
        }


    }
}
