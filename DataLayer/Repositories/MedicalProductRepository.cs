using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
namespace DataLayer.Repositories
{
    public class MedicalProductRepository : GenericRepository<MedicalProductEntity, int>, IMedicalProductRepository
    {
        public MedicalProductRepository(DbContext context) : base(context)
        {

        }
    }
}
