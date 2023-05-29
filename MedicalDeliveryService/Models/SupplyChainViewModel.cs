using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class SupplyChainViewModel
    {
        public SupplyChainViewModel(Supplier supplier, Factory factory, City city, City destination, DeliveryCompany company, MedicalProduct product)
        {
            Supplier = supplier;
            Factory = factory;
            City = city;
            Destination = destination;
            Company = company;
            Product = product;
        }

        public Supplier Supplier { get; set; }

        public Factory Factory { get; set; }

        public City City { get; set; }

        public City Destination { get; set; }

        public DeliveryCompany Company { get; set; }

        public MedicalProduct Product { get; set; }
    }
}
