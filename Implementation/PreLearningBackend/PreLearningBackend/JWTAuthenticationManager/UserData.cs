using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.JWTAuthenticationManager
{
    public class UserData
    {
        public string Token { get; set; }

        public int RoleId { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}
