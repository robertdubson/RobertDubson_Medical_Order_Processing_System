using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class StatusMapper : IMapper<StatusEntity, Status>
    {
        public StatusEntity FromDomainToEntity(Status example)
        {
            return new StatusEntity(example.ID, example.StatusName);
        }

        public Status FromEntityToDomain(StatusEntity example)
        {
            return new Status(example.ID, example.StatusName);
        }
    }
}
