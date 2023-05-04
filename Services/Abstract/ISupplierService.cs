using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
namespace Services.Abstract
{
    public interface ISupplierService
    {
        public List<Supplier> GetAllSuppliers();

        public Supplier GetById(int id);

        public void Delete(int id);

        public void Add(Supplier example);

        public void Update(Supplier example);
    }
}
