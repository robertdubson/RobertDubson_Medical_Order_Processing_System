using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
namespace MedicalDeliveryService.Models
{
    public class AddingProductToStockViewModel
    {
        public int ProductAndFatoryID { get; set; }
        
        public List<SelectListItem> PossibleProducts { get; set; }

        public List<MedicalProduct> ProductModels { get; set; }

        public MedicalProduct Product { get; set; }

        public int UnitsInStock { get; set; }

        public int FactoryID { get; set; }

        public AddingProductToStockViewModel(int factoryId, List<MedicalProduct> products)
        {
            ProductModels = products;

            PossibleProducts = new List<SelectListItem>();

            products.ForEach(pr => PossibleProducts.Add(new SelectListItem(pr.ProductName, pr.ID.ToString())));

            FactoryID = factoryId;

        }

        public AddingProductToStockViewModel(int pandFID, MedicalProduct product, int factoryId, List<MedicalProduct> products, int unitsInStock)
        {
            ProductModels = products;

            PossibleProducts = new List<SelectListItem>();

            products.ForEach(pr => PossibleProducts.Add(new SelectListItem(pr.ProductName, pr.ID.ToString())));

            FactoryID = factoryId;

            UnitsInStock = unitsInStock;

            ProductAndFatoryID = pandFID;

            Product = product;
        }

    }
}
