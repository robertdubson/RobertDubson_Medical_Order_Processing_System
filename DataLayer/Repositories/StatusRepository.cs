using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class StatusRepository : GenericRepository<StatusEntity, int>, IStatusRepository
    {
        public StatusRepository(DbContext context) : base(context)
        {

        }
    }
}
