using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class DeliveryCompanyRepository : GenericRepository<DeliveryCompanyEntity, int>, IDeliveryCompanyRepository
    {
        public DeliveryCompanyRepository(DbContext context) : base(context)
        {

        }
    }
}
