using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class DeliveryCompanyViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double PriceForKm { get; set; }

        public List<CompanyDetailsViewModel> CompanyDetails { get; set; }

        public DeliveryCompanyViewModel(int id, string name, double price, List<CompanyDetailsViewModel> companyDetails)
        {
            Name = name;

            PriceForKm = price;

            ID = id;

            CompanyDetails = companyDetails;
        }
    }
}
