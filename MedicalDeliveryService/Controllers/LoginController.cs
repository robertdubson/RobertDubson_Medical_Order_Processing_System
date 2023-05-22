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
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        IUnitOfWork _unitOfWork;

        IUserService _userService;

        public LoginController(ILogger<LoginController> logger, IUnitOfWork uof)
        {
            _unitOfWork = uof;

            _logger = logger;

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());
        }
        [HttpGet]
        public IActionResult Hello() 
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult LogIn() 
        {
            string pas = Request.Form["Password"];

            string name = Request.Form["UserName"];

            if (_userService.GetAdminByUserName(name) != null)
            {
                return View("Index", "Home");
            }
            else if (_userService.GetClientByUserName(name) != null)
            {
                return View("WelcomeCLient", "Client");
            }
            else if (_userService.GetDoctorByUserName(name) != null)
            {
                return View("WelcomeDoctor", "Doctor");
            }
            else 
            {
                return View("Login");
            }

        }

        public IActionResult SignUp() 
        {
            return View("SignUp");
        }
    }
}
