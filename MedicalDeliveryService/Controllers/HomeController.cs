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
using Microsoft.EntityFrameworkCore;
using DataLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
namespace MedicalDeliveryService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IUnitOfWork _unitOfWork;

        IUserService _userService;

        ICityService _cityService;
        
        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;

            _unitOfWork = new UnitOfWork(applicationContext);

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

            _userService.GetAllClients().ForEach(cl => models.Add(new ClientsViewModel(cl.ID, cl.Name, cl.LocationID, cl.PasswordHash, cl.UserName)));

            return View("AllClients", models);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Client user = _userService.GetClietnById(id);


            return View("ClientUpdate", new ClientCreationViewModel(_cityService.GetAllCities(), user.ID.ToString(), user.Name, user.UserName, user.LocationID, user.PasswordHash));
        }

        [HttpPost]
        public IActionResult UpdateClient() 
        {
            ClientCreationViewModel viewModel = new ClientCreationViewModel();

            viewModel.SelectedCityIDStr = Request.Form["SelectedCityIDStr"];
            viewModel.InsertedPassword = Request.Form["InsertedPassword"];
            viewModel.OfficialName = Request.Form["OfficialName"];
            viewModel.UserName = Request.Form["UserName"];
            viewModel.StrId = Request.Form["StrId"];

            _userService.UpdateClient(new Client(int.Parse(viewModel.StrId), viewModel.OfficialName, int.Parse(viewModel.SelectedCityIDStr), _userService.GetHash(viewModel.InsertedPassword), viewModel.UserName));
            _unitOfWork.Complete();
            return View("Index");
        }

        [HttpGet]
        public IActionResult StartClientCreation() 
        {
            return View("ClientCreation", new ClientCreationViewModel(_cityService.GetAllCities()));

        }

        [HttpPost]
        public IActionResult CreateClient() 
        {
            ClientCreationViewModel viewModel = new ClientCreationViewModel();

            viewModel.SelectedCityIDStr = Request.Form["SelectedCityIDStr"];
            viewModel.InsertedPassword = Request.Form["InsertedPassword"];
            viewModel.OfficialName = Request.Form["OfficialName"];
            viewModel.UserName = Request.Form["UserName"];
            _userService.AddClient(viewModel.UserName, _userService.GetHash(viewModel.InsertedPassword), viewModel.OfficialName, int.Parse(viewModel.SelectedCityIDStr));
            _unitOfWork.Complete();

            return View("Index");
        }

        public IActionResult DeleteClient(int id) 
        {
            _userService.RemoveClient(id);
            _unitOfWork.Complete();

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
