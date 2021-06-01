﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.JWTAuthenticationManager
{
    public interface IJWTAuthentication
    {
        string Login(string email, string password);
    }
}

