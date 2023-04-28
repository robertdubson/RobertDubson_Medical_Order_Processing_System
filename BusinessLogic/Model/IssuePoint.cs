using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class IssuePoint : BaseModel
    {

        public int CityID { get; set; }

        public string Address { get; set; }

        public IssuePoint(int id, int cityId, string address)
        {
            ID = id;

            CityID = cityId;

            Address = address;
        }

        public IssuePoint(int cityId, string address)
        {
            CityID = cityId;

            Address = address;
        }
    }
}
