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

        ISupplierService _supplierService;

        IFactoryService _factoryService;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;

            _unitOfWork = new UnitOfWork(applicationContext);

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());

            _cityService = new CityService(_unitOfWork, new CityMapper(), new DeliveryCompanyAndCityMapper());

            _supplierService = new SupplierService(_unitOfWork, new SupplierMapper(), new SupplierAndProductMapper());

            _factoryService = new FactoryService(_unitOfWork, new FactoryMapper());
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

            _userService.GetAllClients().ForEach(cl => models.Add(new ClientsViewModel(cl.ID, cl.Name, _cityService.GetCityById(cl.LocationID), cl.PasswordHash, cl.UserName)));

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
        [HttpGet]
        public IActionResult DeleteClient(int id)
        {
            _userService.RemoveClient(id);
            _unitOfWork.Complete();

            return View("Index");
        }
        [HttpGet]
        public IActionResult AllSuppliers()
        {
            //List<SupplierViewModel> models = new List<SupplierViewModel>();
            //_supplierService.GetAllSuppliers().


            return View("AllSuppliers", _supplierService.GetAllSuppliers().Select(sup => new SupplierViewModel(sup.ID, sup.Name)));
        }
        [HttpGet]
        public IActionResult CreateSupplier()
        {
            return View("CreateSupplier");
        }
        [HttpPost]
        public IActionResult AddSupplier()
        {
            string Name = Request.Form["Name"];

            _supplierService.Add(new Supplier(Name));
            _unitOfWork.Complete();

            return View("AllSuppliers", _supplierService.GetAllSuppliers().Select(sup => new SupplierViewModel(sup.ID, sup.Name)));
        }

        [HttpGet]
        public IActionResult EditSupplier(int Id)
        {
            return View("EditSupplier", new SupplierViewModel(Id, _supplierService.GetById(Id).Name));
        }

        [HttpPost]
        public IActionResult UpdateSupplier()
        {

            string strID = Request.Form["ID"];

            string Name = Request.Form["Name"];

            _supplierService.Update(new Supplier(Convert.ToInt32(strID), Name));
            _unitOfWork.Complete();

            return View("AllSuppliers", _supplierService.GetAllSuppliers().Select(sup => new SupplierViewModel(sup.ID, sup.Name)));
        }

        [HttpGet]
        public IActionResult DeleteSupplier(int Id)
        {

            _supplierService.Delete(Id);
            _unitOfWork.Complete();

            return View("AllSuppliers", _supplierService.GetAllSuppliers().Select(sup => new SupplierViewModel(sup.ID, sup.Name)));
        }
        [HttpGet]
        public IActionResult AllFactories()
        {
            return View("AllFactories", _factoryService.GetAllFactories().Select(fac => new FactoryViewModel(fac.ID, _cityService.GetCityById(fac.CityID), _supplierService.GetById(fac.CompanyID), fac.Address)));
        }
        [HttpGet]
        public IActionResult CreateFactory()
        {
            return View("FactoryCreation", new FactoryViewModel(_cityService.GetAllCities(), _supplierService.GetAllSuppliers()));
        }
        [HttpPost]
        public IActionResult AddFactory()
        {
            string Address = Request.Form["Address"];
            string SupIdStr = Request.Form["CompanyID"];
            string CityIdStr = Request.Form["CityID"];

            _factoryService.AddFactory(new Factory(int.Parse(CityIdStr), Address, int.Parse(SupIdStr)));
            _unitOfWork.Complete();

            return View("AllFactories", _factoryService.GetAllFactories().Select(fac => new FactoryViewModel(fac.ID, _cityService.GetCityById(fac.CityID), _supplierService.GetById(fac.CompanyID), fac.Address)));
        }
        [HttpGet]
        public IActionResult EditFactory(int Id)
        {
            Factory currentFactory = _factoryService.GetFactory(Id);

            return View("EditFactory", new FactoryViewModel(Id, currentFactory.CityID, currentFactory.Address, currentFactory.CompanyID, _cityService.GetAllCities(), _supplierService.GetAllSuppliers()));
        }
        [HttpPost]
        public IActionResult UpdateFactory() 
        {
            string strId = Request.Form["FactoryId"];
            string Address = Request.Form["Address"];
            string SupIdStr = Request.Form["CompanyID"];
            string CityIdStr = Request.Form["CityID"];

            _factoryService.UpdateFactory(new Factory(int.Parse(strId), int.Parse(CityIdStr), Address, int.Parse(SupIdStr)));
            _unitOfWork.Complete();

            return View("AllFactories", _factoryService.GetAllFactories().Select(fac => new FactoryViewModel(fac.ID, _cityService.GetCityById(fac.CityID), _supplierService.GetById(fac.CompanyID), fac.Address)));
        }

        public IActionResult DeleteFactory(int Id) 
        {
            _factoryService.DeleteFactory(Id);
            _unitOfWork.Complete();
            
            return View("AllFactories", _factoryService.GetAllFactories().Select(fac => new FactoryViewModel(fac.ID, _cityService.GetCityById(fac.CityID), _supplierService.GetById(fac.CompanyID), fac.Address)));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
