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
    

    [Authorize(Roles = "Client")]
    
    public class ClientController : Controller
    {
        IReceiptService _receiptService;

        IUserService _userService;

        IUnitOfWork _unitOfWork;

        IProductService _productService;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());

            _receiptService = new ReceiptService(_unitOfWork);

            _productService = new ProductService(_unitOfWork, new MedicalProductMapper(), new ProductAndFactoryMapper());

        }
        [HttpGet]
        public IActionResult WelcomeClient()
        {
            int id = (int)HttpContext.Session.GetInt32("UserId");
            List<ReceiptViewModel> viewModels = new List<ReceiptViewModel>();
            _receiptService.GetAllReceiptsByClientId(id).ForEach(r => viewModels.Add(new ReceiptViewModel(_receiptService.GetPrescriptedProducts(r.ID), r, _userService.GetDoctorById(r.AuthorID))));

            return View("WelcomeClient", viewModels);
        }

        [HttpGet]
        public IActionResult ReceiptConfirmation(int Id) 
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

            return View("ReceiptConfirmation", new ReceiptViewModel(productsToConfirm, r, _userService.GetDoctorById(r.AuthorID)));
        }

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
            ReceiptService receiptService = new ReceiptService(unitOfWork);
            int userid = (int)HttpContext.Session.GetInt32("UserId");
            List<ReceiptViewModel> viewModels = new List<ReceiptViewModel>();
            receiptService.GetAllReceiptsByClientId(userid).ForEach(r => viewModels.Add(new ReceiptViewModel(_receiptService.GetPrescriptedProducts(r.ID), r, _userService.GetDoctorById(r.AuthorID))));

            return View("WelcomeClient", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Hello", "Login");
        }
    }
}
