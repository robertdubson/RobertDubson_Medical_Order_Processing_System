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
using MedicalDeliveryService.Models.LoginViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MedicalDeliveryService.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        IUnitOfWork _unitOfWork;

        IUserService _userService;

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public LoginController(ILogger<LoginController> logger, IUnitOfWork uof)
        {
            _unitOfWork = uof;

            _logger = logger;

            _userService = new UserService(_unitOfWork, new DoctorMapper(), new ClientMapper());

            

            
        }



        [HttpGet]
        public async Task<IActionResult> Hello() 
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, "Aynonymus"));
            claims.Add(new Claim(ClaimTypes.Role, "Aynonymus"));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return View("Login", new LoginViewModel("", ""));
        }

        [HttpPost]
        public async Task<IActionResult> LogIn() 
        {
            string pas = Request.Form["Password"];

            string name = Request.Form["UserName"];

            var user = _userService.GetAdminByUserName(name);

            var claims = new List<Claim>();

            if (user != null && user.PasswordHash==_userService.GetHash(pas))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetInt32("UserId", user.ID);

                return RedirectToAction("Index", "Home");
            }
            else 
            {
                var cluser = _userService.GetClientByUserName(name);
                if (cluser != null)
                {
                    if (_userService.GetHash(pas) == cluser.PasswordHash)
                    {
                        claims.Add(new Claim(ClaimTypes.Name, cluser.UserName));
                        claims.Add(new Claim(ClaimTypes.Role, "Client"));

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetInt32("UserId", cluser.ID);

                        return RedirectToAction("WelcomeClient", "Client");
                    }
                }
                else 
                {
                    var doctor = _userService.GetDoctorByUserName(name);
                    if (doctor != null) 
                    {
                        if (_userService.GetHash(pas)==doctor.PasswordHash) 
                        {
                            claims.Add(new Claim(ClaimTypes.Name, doctor.UserName));
                            claims.Add(new Claim(ClaimTypes.Role, "Doctor"));

                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            HttpContext.Session.SetInt32("UserId", doctor.ID);

                            return RedirectToAction("WelcomeDoctor", "Doctor");
                        }
                        
                    }
                    return View("Error", new ErrorViewModel("Sorry, we did not authenticate user"));
                }
                return View("Error", new ErrorViewModel("Sorry, we did not authenticate user"));
            }

        }
        

        public IActionResult SignUp() 
        {
            return View("SignUp");
        }
    }
}
