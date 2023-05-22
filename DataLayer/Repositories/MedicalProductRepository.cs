using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using DataLayer.Repositories.Abstract;
using System.Linq;
namespace DataLayer.Repositories
{
    public class MedicalProductRepository : GenericRepository<MedicalProductEntity, int>, IMedicalProductRepository
    {
        public MedicalProductRepository(DbContext context) : base(context)
        {

        }

        public double GetPrice(int FactoryId, int ProductId)            
        {
            SupplierEntity supplier = Context.Set<SupplierEntity>().Find(Context.Set<FactoryEntity>().Find(FactoryId).CompanyID);

            SupplierAndProductEntity priceItem = new SupplierAndProductEntity();
            
            foreach (SupplierAndProductEntity sp in Context.Set<SupplierAndProductEntity>()) 
            {
                if (sp.ProductID == ProductId && sp.SupplierID == supplier.ID)
                {
                    return sp.Price;
                }
                else 
                {
                    priceItem=null;
                }
            }
            if (priceItem == null)
            {
                return Context.Set<SupplierAndProductEntity>().Find(Context.Set<FactoryEntity>().Find(FactoryId).CompanyID).Price;
            }
            else 
            {
                return priceItem.Price;
            }

            
        }
    }
}
