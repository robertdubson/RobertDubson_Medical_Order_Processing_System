﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IUser
    {
        public bool Login(string password, string username);
        
        public void Logout();

    }
}
