﻿using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public interface IMindTreeMindRegisterService
    {
        Task<bool> AddDetails(MindTreeMindRegister mindTreeMindDetails);
    }
}
