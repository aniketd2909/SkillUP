using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Models.User
{
    public class MindTreeMindRegister
    {
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Track { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
