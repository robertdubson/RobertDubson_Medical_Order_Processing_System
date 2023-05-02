using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class IssuePointEntity : BaseEntity
    {
        public int CityID { get; set; }

        public string Address { get; set; }

        public IssuePointEntity(int id, int cityId, string address)
        {
            ID = id;

            CityID = cityId;

            Address = address;
        }

        public IssuePointEntity()
        {

        }
    }
}
