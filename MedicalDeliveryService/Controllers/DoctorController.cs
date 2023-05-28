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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MedicalDeliveryService.Controllers
{

    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {

        IUnitOfWork _unitOfWork;

        IUserService _userService;

        IReceiptService _receiptService;

        IProductService _productService;

        ICityService _cityService;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());

            _receiptService = new ReceiptService(_unitOfWork);

            _productService = new ProductService(_unitOfWork, new MedicalProductMapper(), new ProductAndFactoryMapper());

            _cityService = new CityService(_unitOfWork, new CityMapper(), new DeliveryCompanyAndCityMapper());
        }

        [HttpGet]
        public IActionResult AllClients() 
        {
            List<ClientsViewModel> models = new List<ClientsViewModel>();

            _userService.GetAllClients().ForEach(cl => models.Add(new ClientsViewModel(cl.ID, cl.Name, _cityService.GetCityById(cl.LocationID), cl.PasswordHash, cl.UserName, cl.Phone, cl.EMail)));

            return View("AllClients", models);
        }

        [HttpGet]
        public IActionResult ReceiptForClient(int Id) 
        {
            Client client = _userService.GetClietnById(Id);

            Doctor doctor = _userService.GetDoctorById((int)HttpContext.Session.GetInt32("UserId"));

            ReceiptPreparationViewModel viewModel = new ReceiptPreparationViewModel(_productService.GetAllProducts(), client, doctor);

            return View("ReceiptForClient", viewModel);

        }

        [HttpPost]
        public IActionResult AddReceipt() 
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
            for (int i = 0; i < count; i++)
            {
                string IdProdStr = Request.Form["PrescriptedProducts[" + i.ToString() + "].ID"];
                int prodId = int.Parse(IdProdStr);
                selectedProducts.Add(_productService.GetProduct(prodId));
            }
            List<ReceiptAndProduct> solutions = _receiptService.GenerateOptimizedReceipt(destination, selectedProducts);
            solutions.ForEach(solution => _receiptService.AddSolution(solution));

            AlgorithmLogger logger = _receiptService.GetLogger();
            _unitOfWork.Complete();
            double cost = 0;
            solutions.ForEach(solution => cost += _productService.GetPrice(solution.FactoryID, solution.ProductID));
            Receipt receipt = new Receipt(clientId, doctorId, review, 2, true, destination.ID, cost);
            receipt.Cost = cost;
            receipt.CreationDate = DateTime.Now.ToString();
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

            return View("ReceiptConfirmationView", new ReceiptViewModel(productsToConfirm, receipt, _userService.GetDoctorById(doctorId), logger));

        }


        [HttpGet]
        public IActionResult NewReceipt() 
        {
            Doctor doctor = _userService.GetDoctorById((int)HttpContext.Session.GetInt32("UserId"));

            ReceiptPreparationViewModel viewModel = new ReceiptPreparationViewModel(_productService.GetAllProducts(), _userService.GetAllClients(), doctor);

            return View("NewReceipt", viewModel);

        }

        [HttpPost]
        public IActionResult ProcessNewReceipt() 
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
            for (int i = 0; i < count; i++)
            {
                string IdProdStr = Request.Form["PrescriptedProducts[" + i.ToString() + "].ID"];
                int prodId = int.Parse(IdProdStr);
                selectedProducts.Add(_productService.GetProduct(prodId));
            }
            List<ReceiptAndProduct> solutions = _receiptService.GenerateOptimizedReceipt(destination, selectedProducts);
            solutions.ForEach(solution => _receiptService.AddSolution(solution));
            AlgorithmLogger logger = _receiptService.GetLogger();
            _unitOfWork.Complete();
            double cost = 0;
            solutions.ForEach(solution => cost += _productService.GetPrice(solution.FactoryID, solution.ProductID));
            Receipt receipt = new Receipt(clientId, doctorId, review, 2, true, destination.ID, cost);
            receipt.Cost = cost;
            receipt.CreationDate = DateTime.Now.ToString();
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

            return View("ReceiptConfirmationView", new ReceiptViewModel(productsToConfirm, receipt, _userService.GetDoctorById(doctorId), logger));
        }

        [HttpGet]
        public IActionResult WelcomeDoctor()
        {
            int id = (int)HttpContext.Session.GetInt32("UserId");
            List<ReceiptViewModel> viewModels = new List<ReceiptViewModel>();
            _receiptService.GetAllReceiptsByDoctorId(id).ForEach(r => viewModels.Add(new ReceiptViewModel(_receiptService.GetPrescriptedProducts(r.ID), r, _userService.GetDoctorById(r.AuthorID), _userService.GetClietnById(r.ClientID))));

            return View("WelcomeDoctor", viewModels);
        }
        [HttpGet]
        public IActionResult ReceiptDetails(int Id) 
        {
            Receipt r = _receiptService.GetReceiptById(Id);
            List<MedicalProduct> productsToConfirm = new List<MedicalProduct>();



            foreach (ReceiptAndProduct solution in _receiptService.GetReceiptDetails(Id))
            {
                double price = _productService.GetPrice(solution.FactoryID, solution.ProductID);
                MedicalProduct prod = _productService.GetProduct(solution.ProductID);
                prod.Price = price;
                productsToConfirm.Add(prod);
            }
            return View("ReceiptDetails", new ReceiptViewModel(productsToConfirm, r, _userService.GetDoctorById(r.AuthorID)));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Hello", "Login");
        }
    }
}
