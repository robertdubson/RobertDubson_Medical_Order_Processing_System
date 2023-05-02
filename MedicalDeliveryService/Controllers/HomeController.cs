using MedicalDeliveryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Services.Abstract;
using DataLayer.UnitOfWork;
using Mappers;
using BusinessLogic;
namespace MedicalDeliveryService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IUnitOfWork _unitOfWork;

        IUserService _userService;

        ICityService _cityService;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;

            _unitOfWork = unitOfWork;

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());

            _cityService = new CityService(_unitOfWork, new CityMapper(), new DeliveryCompanyAndCityMapper());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult AllClients() 
        {

            List<ClientsViewModel> models = new List<ClientsViewModel>();

            _unitOfWork.ClientRepository.GetAll().ToList().ForEach(cl => models.Add(new ClientsViewModel(cl.ID, cl.ClientName, cl.LocationID, cl.PasswordHash, cl.UserName)));

            models.Add(new ClientsViewModel(1, "sdgfdgsf", 1, "asdasd", "asfafg"));
            models.Add(new ClientsViewModel(2, "sdgfdgsf", 1, "asdasd", "asfafg"));
            models.Add(new ClientsViewModel(3, "sdgfdgsf", 1, "asdasd", "asfafg"));
            models.Add(new ClientsViewModel(4, "sdgfdgsf", 1, "asdasd", "asfafg"));

            return View("AllClients", models);
        }

        [HttpGet]
        public IActionResult StartClientCreation() 
        {
            //return View("ClientCreation", new ClientCreationViewModel(_cityService.GetAllCities()));

            List<City> models = new List<City>();

            models.Add(new City(1, "Kyiv", 1, 2));

            models.Add(new City(2, "Kryvyi Rih", 1, 2));

            models.Add(new City(3, "Feodosia", 1, 2));

            ViewData["SelectedCityIDStr"] = "1";

            ClientCreationViewModel cm = new ClientCreationViewModel(models);

            return View("ClientCreation", cm);
        }

        [HttpPost]
        public IActionResult CreateClient(ClientCreationViewModel viewModel) 
        {

            List<ClientsViewModel> models = new List<ClientsViewModel>();

            _userService.AddClient(viewModel.UserName, _userService.GetHash(viewModel.InsertedPassword), viewModel.OfficialName, viewModel.SelectedCity.ID);            
            _unitOfWork.ClientRepository.GetAll().ToList().ForEach(cl => models.Add(new ClientsViewModel(cl.ID, cl.ClientName, cl.LocationID, cl.PasswordHash, cl.UserName)));

            models.Add(new ClientsViewModel(1, "sdgfdgsf", 1, "asdasd", "asfafg"));
            models.Add(new ClientsViewModel(2, "sdgfdgsf", 1, "asdasd", "asfafg"));
            models.Add(new ClientsViewModel(3, "sdgfdgsf", 1, "asdasd", "asfafg"));
            models.Add(new ClientsViewModel(4, "sdgfdgsf", 1, "asdasd", "asfafg"));

            return View("AllClients");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
