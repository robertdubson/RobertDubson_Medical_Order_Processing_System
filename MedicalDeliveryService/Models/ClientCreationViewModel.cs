using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalDeliveryService.Models
{
    public class ClientCreationViewModel : PageModel
    {

        public List<City> CityModels { get; set; }

        public string SelectedCityIDStr { get; set; }

        public ClientCreationViewModel()
        {

        }
        
        public ClientCreationViewModel(List<City> allCities)
        {
            AllCities = new List<SelectListItem>();
            
            allCities.ForEach(c => AllCities.Add(new SelectListItem(c.CityName, c.ID.ToString())));

            CityModels = allCities;
        }

        public List<SelectListItem> AllCities { get; set; }

        public City SelectedCity { get { return CityModels.Find(c => c.ID == int.Parse(SelectedCityIDStr)); } }

        public string InsertedPassword { get; set; }

        public string UserName { get; set; }

        public string OfficialName { get; set; }



            
    }
}
