using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDeliveryService.Models.LoginViewModels
{
    public class LoginViewModel
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public LoginViewModel(string username, string pas)
        {
            UserName = username;

            Password = pas;
        }
    }
}
