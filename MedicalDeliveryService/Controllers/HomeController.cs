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
using System.IO;
using Microsoft.Extensions.FileProviders;

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

        IProductService _productService;

        IReceiptService _receiptService;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;

            _unitOfWork = new UnitOfWork(applicationContext);

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());

            _cityService = new CityService(_unitOfWork, new CityMapper(), new DeliveryCompanyAndCityMapper());

            _supplierService = new SupplierService(_unitOfWork, new SupplierMapper(), new SupplierAndProductMapper());

            _factoryService = new FactoryService(_unitOfWork, new FactoryMapper());

            _productService = new ProductService(_unitOfWork, new MedicalProductMapper(), new ProductAndFactoryMapper());

            _receiptService = new ReceiptService(_unitOfWork);
        }

        public ActionResult Report()
        {
            
            return View("AdminReport");
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
        public IActionResult ClientDetails(int id) 
        {
            List<ReceiptViewModel> viewModels = new List<ReceiptViewModel>();
            _receiptService.GetAllReceiptsByClientId(id).ForEach(r => viewModels.Add(new ReceiptViewModel(_receiptService.GetPrescriptedProducts(r.ID), r, _userService.GetDoctorById(r.AuthorID))));
            
            return View("ClientDetails", viewModels);
        }
        [HttpGet]
        public IActionResult ReceiptConfirmation(int id) 
        {
            Receipt r = _receiptService.GetReceiptById(id);
            List<MedicalProduct> productsToConfirm = new List<MedicalProduct>();

            

            foreach (ReceiptAndProduct solution in _receiptService.GetReceiptDetails(id))
            {
                double price = _productService.GetPrice(solution.FactoryID, solution.ProductID);
                MedicalProduct prod = _productService.GetProduct(solution.ProductID);
                prod.Price = price;
                productsToConfirm.Add(prod);
            }

            return View("ReceiptStatus", new ReceiptViewModel(productsToConfirm, r, _userService.GetDoctorById(r.AuthorID)));
        }
        [HttpPost]
        public IActionResult ConfirmReceipt() 
        {
            string strId = Request.Form["receiptId"];
            int id = int.Parse(strId);
            Receipt r = _receiptService.GetReceiptById(id);
            r.OrderStatusID = 1;
            Receipt newRec = new Receipt(id, r.ClientID, r.AuthorID, r.AppointmentReview, r.OrderStatusID, r.ShipToTheIssuePoint, r.DestinationCityID, r.CreationDate, r.Cost);
            newRec.Cost = r.Cost;
            UnitOfWork unitOfWork = new UnitOfWork(new ApplicationContext());
            unitOfWork.ReceiptRepository.Update(new DataModel.ReceiptEntity(id, r.ClientID, r.AuthorID, r.AppointmentReview, r.OrderStatusID, r.ShipToTheIssuePoint, r.DestinationCityID, r.CreationDate, r.Cost));
            //_receiptService.UpdateReceipt(r);
            unitOfWork.Complete();

            List<ClientsViewModel> models = new List<ClientsViewModel>();

            _userService.GetAllClients().ForEach(cl => models.Add(new ClientsViewModel(cl.ID, cl.Name, _cityService.GetCityById(cl.LocationID), cl.PasswordHash, cl.UserName)));

            return View("AllClients", models);
        }


        [HttpGet]
        public IActionResult AllSuppliers()
        {
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
        [HttpGet]
        public IActionResult DeleteFactory(int Id) 
        {
            _factoryService.DeleteFactory(Id);
            _unitOfWork.Complete();
            
            return View("AllFactories", _factoryService.GetAllFactories().Select(fac => new FactoryViewModel(fac.ID, _cityService.GetCityById(fac.CityID), _supplierService.GetById(fac.CompanyID), fac.Address)));
        }
        [HttpGet]
        public IActionResult FactoryDetails(int Id) 
        {

            List<FactoryDetailsViewModel> models = new List<FactoryDetailsViewModel>();
            //Dictionary<MedicalProduct, int> dict = _factoryService.AvailableProducts(Id);
            //dict.Keys.ToList().ForEach(prod => models.Add(new FactoryDetailsViewModel(Id, _factoryService.GetFactory(Id), prod, dict[prod])));
            _factoryService.GetAllFactoryDetails().FindAll(fac => fac.FactoryID==Id).ForEach(pf => models.Add(new FactoryDetailsViewModel(pf.ID, _factoryService.GetFactory(Id), _productService.GetProduct(pf.ProductID), pf.UnitsInStorage)));
            return View("FactoryDetails", models);
        }
        [HttpGet]
        public IActionResult AddProductToStock(int Id) 
        {
            return View("AddProductToStock", new AddingProductToStockViewModel(Id, _productService.GetAllProducts()));
        }
        [HttpPost]
        public IActionResult CreateProductToStock() 
        {
            string strId = Request.Form["FactoryID"];
            int Id = int.Parse(strId);
            string prodIdStr = Request.Form["Product"];
            string UnitsInStockStr = Request.Form["UnitsInStock"];
            int unitsInStock = int.Parse(UnitsInStockStr);
            int ProdId = int.Parse(prodIdStr);
            _factoryService.AddFactoryDetails(Id, ProdId, unitsInStock);
            _unitOfWork.Complete();

            List<FactoryDetailsViewModel> models = new List<FactoryDetailsViewModel>();
            _factoryService.GetAllFactoryDetails().FindAll(fac => fac.FactoryID == Id).ForEach(pf => models.Add(new FactoryDetailsViewModel(pf.ID, _factoryService.GetFactory(Id), _productService.GetProduct(pf.ProductID), pf.UnitsInStorage)));
            return View("FactoryDetails", models);
        }
        [HttpGet]
        public IActionResult EditFactoryDetails(int Id) 
        {
            ProductAndFactory pF = _factoryService.GetFactoryDetails(Id);           
            return View("EditFactoryDetails", new AddingProductToStockViewModel(pF.ID, _productService.GetProduct(pF.ProductID), pF.FactoryID, _productService.GetAllProducts(), pF.UnitsInStorage));
        }
        [HttpPost]
        public IActionResult UpdateFactoryDetails() 
        {
            string strId = Request.Form["ID"];
            string strFactId = Request.Form["FactoryID"];
            int FactoryId = int.Parse(strFactId);
            string prodIdStr = Request.Form["Product"];
            string UnitsInStockStr = Request.Form["UnitsInStock"];
            _factoryService.UpdateFactoryDetails(new ProductAndFactory(int.Parse(strId), int.Parse(strFactId), int.Parse(prodIdStr), int.Parse(UnitsInStockStr)));
            _unitOfWork.Complete();
            List<FactoryDetailsViewModel> models = new List<FactoryDetailsViewModel>();
            _factoryService.GetAllFactoryDetails().FindAll(fac => fac.FactoryID == int.Parse(strFactId)).ForEach(pf => models.Add(new FactoryDetailsViewModel(pf.ID, _factoryService.GetFactory(int.Parse(strFactId)), _productService.GetProduct(pf.ProductID), pf.UnitsInStorage)));
            return View("FactoryDetails", models);
        }
        [HttpPost]
        public IActionResult DeleteFactoryDetails() 
        {

            string productAndFactoryId = Request.Form["ID"];
            _factoryService.DeleteFactoryDetail(int.Parse(productAndFactoryId));
            _unitOfWork.Complete();
            string strFactId = Request.Form["FactoryID"];
            List<FactoryDetailsViewModel> models = new List<FactoryDetailsViewModel>();
            Dictionary<MedicalProduct, int> dict = _factoryService.AvailableProducts(int.Parse(strFactId));
            dict.Keys.ToList().ForEach(prod => models.Add(new FactoryDetailsViewModel(int.Parse(strFactId), _factoryService.GetFactory(int.Parse(strFactId)), prod, dict[prod])));
            return View("FactoryDetails", models);
        }
        [HttpGet]
        public IActionResult AllProducts() 
        {
            return View("AllProducts", _productService.GetAllProducts().Select(prod => new MedicalProductViewModel(prod.ID, prod.ProductName, prod.Description, prod.InstructionToUse)).ToList());
        }
        [HttpGet]
        public IActionResult CreateProduct() 
        {
            return View("CreateProduct");
        }
        [HttpPost]
        public IActionResult AddProduct() 
        {

            string prodName = Request.Form["ProductName"];
            string description = Request.Form["Description"];
            string instructions = Request.Form["InstructionToUse"];
            _productService.AddProduct(new MedicalProduct(prodName, description, instructions));
            _unitOfWork.Complete();
            

            return View("AllProducts", _productService.GetAllProducts().Select(prod => new MedicalProductViewModel(prod.ID, prod.ProductName, prod.Description, prod.InstructionToUse)).ToList());
        }
        [HttpGet]
        public IActionResult EditProduct(int Id) 
        {
            MedicalProduct currentProd = _productService.GetProduct(Id);

            return View("EditProduct", new MedicalProductViewModel(currentProd.ID, currentProd.ProductName, currentProd.Description, currentProd.InstructionToUse));
        }
        [HttpPost]
        public IActionResult UpdateProduct() 
        {
            string Idstr = Request.Form["ID"];
            string prodName = Request.Form["ProductName"];
            string description = Request.Form["Description"];
            string instructions = Request.Form["InstructionToUse"];
            _productService.UpdateProduct(new MedicalProduct(int.Parse(Idstr), prodName, description, instructions));
            _unitOfWork.Complete();
            return View("AllProducts", _productService.GetAllProducts().Select(prod => new MedicalProductViewModel(prod.ID, prod.ProductName, prod.Description, prod.InstructionToUse)).ToList());
        }

        [HttpGet]
        public IActionResult DeleteProduct(int Id) 
        {
            _productService.DeleteProduct(Id);
            _unitOfWork.Complete();

            return View("AllProducts", _productService.GetAllProducts().Select(prod => new MedicalProductViewModel(prod.ID, prod.ProductName, prod.Description, prod.InstructionToUse)).ToList());
        }

        [HttpGet]
        public IActionResult AllDoctors() 
        {
            return View("AllDoctors", _userService.GetAllDoctors().Select(dc => new DoctorViewModel(dc.ID, dc.Name, dc.PasswordHash, dc.UserName)).ToList());
        }

        [HttpGet]
        public IActionResult CreateDoctor() 
        {
            return View("CreateDoctor");
        }

        [HttpPost]
        public IActionResult AddDoctor() 
        {
            string Name = Request.Form["Name"];
            string UserName = Request.Form["UserName"];
            string Password = Request.Form["Password"];
            string passwordHash = _userService.GetHash(Password);
            _userService.AddDoctor(UserName, passwordHash, Name);
            _unitOfWork.Complete();

            return View("AllDoctors", _userService.GetAllDoctors().Select(dc => new DoctorViewModel(dc.ID, dc.Name, dc.PasswordHash, dc.UserName)).ToList());
        }

        [HttpGet]
        public IActionResult EditDoctor(int Id) 
        {
            Doctor currentDoctor = _userService.GetDoctorById(Id);

            return View("EditDoctor", new DoctorViewModel(Id, currentDoctor.Name, currentDoctor.PasswordHash, currentDoctor.UserName));
        }
        [HttpPost]
        public IActionResult UpdateDoctor() 
        {
            string IdStr = Request.Form["ID"];
            int Id = int.Parse(IdStr);
            string Name = Request.Form["Name"];
            string UserName = Request.Form["UserName"];
            string Password = Request.Form["Password"];
            string passwordHash = _userService.GetHash(Password);
            _userService.UpdateDoctor(new Doctor(Id, Name, passwordHash, UserName));
            _unitOfWork.Complete();

            return View("AllDoctors", _userService.GetAllDoctors().Select(dc => new DoctorViewModel(dc.ID, dc.Name, dc.PasswordHash, dc.UserName)).ToList());
        }

        [HttpGet]
        public IActionResult DeleteDoctor(int Id) 
        {
            _userService.RemoveDoctor(Id);
            _unitOfWork.Complete();

            return View("AllDoctors", _userService.GetAllDoctors().Select(dc => new DoctorViewModel(dc.ID, dc.Name, dc.PasswordHash, dc.UserName)).ToList());
        }
        [HttpGet]
        public IActionResult CreateNewReceipt() 
        {
            ReceiptPreparationViewModel viewModel = new ReceiptPreparationViewModel(_productService.GetAllProducts(), _userService.GetAllClients(), _userService.GetAllDoctors());

            return View("ReceiptCreationView", viewModel);
        }
        
        [HttpPost]
        public IActionResult ProcessReceipt() 
        {
            string countStr = Request.Form["ProductCount"];
            int count = int.Parse(countStr);
            string authorIdStr = Request.Form["AuthorID"];
            string clientIdStr = Request.Form["ClientID"];
            string review = Request.Form["AppointmentReview"];
            //string IsShippingInPoint = Re
            int clientId = int.Parse(clientIdStr);
            int doctorId = int.Parse(authorIdStr);
            Client client = _userService.GetClietnById(clientId);
            City destination = _cityService.GetCityById(client.LocationID);
            List<MedicalProduct> selectedProducts = new List<MedicalProduct>();
            for (int i=0; i<count; i++) 
            {
                string IdProdStr = Request.Form["PrescriptedProducts[" + i.ToString() + "].ID"];
                int prodId = int.Parse(IdProdStr);
                selectedProducts.Add(_productService.GetProduct(prodId));
            }
            List<ReceiptAndProduct> solutions = _receiptService.GenerateOptimizedReceipt(destination, selectedProducts);
            solutions.ForEach(solution => _receiptService.AddSolution(solution));
            _unitOfWork.Complete();
            double cost = 0;
            solutions.ForEach(solution => cost+=_productService.GetPrice(solution.FactoryID, solution.ProductID));
            Receipt receipt = new Receipt(clientId, doctorId, review, 2, true, destination.ID, cost);
            receipt.Cost = cost;
            _receiptService.AddReceipt(receipt);
            _unitOfWork.Complete();
            List<MedicalProduct> productsToConfirm = new List<MedicalProduct>();

            foreach (ReceiptAndProduct solution in solutions) 
            {
                double price = _productService.GetPrice(solution.FactoryID, solution.ProductID);
                MedicalProduct prod = _productService.GetProduct(solution.ProductID);
                prod.Price = price;
                productsToConfirm.Add(prod);
            }

            return View("ReceiptConfirmationView", new ReceiptViewModel(productsToConfirm, receipt, _userService.GetDoctorById(doctorId)));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
