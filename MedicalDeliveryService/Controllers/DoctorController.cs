using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult WelcomeDoctor()
        {
            return View("WelcomeDoctor");
        }
    }
}
