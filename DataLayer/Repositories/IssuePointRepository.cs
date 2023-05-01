using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class IssuePointRepository : GenericRepository<IssuePointEntity, int>, IIssuePointRepository
    {
        public IssuePointRepository(DbContext context) : base(context)
        {

        }
    }
}
