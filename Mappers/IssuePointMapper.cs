using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class IssuePointMapper : IMapper<IssuePointEntity, IssuePoint>
    {
        public IssuePointEntity FromDomainToEntity(IssuePoint example)
        {
            return new IssuePointEntity(example.ID, example.CityID, example.Address);
        }

        public IssuePoint FromEntityToDomain(IssuePointEntity example)
        {
            return new IssuePoint(example.ID, example.CityID, example.Address);
        }
    }
}
