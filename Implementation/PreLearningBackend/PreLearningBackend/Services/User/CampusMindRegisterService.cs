using PreLearningBackend.Context;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public class CampusMindRegisterService : ICampusMindRegisterService
    {
        private readonly AppDbContext _context;
        public CampusMindRegisterService(AppDbContext context)
        {
            _context = context;
        }
        public bool AddDetails(CampusMindRegister register)
        {
            if (ValidateUserEmail(register.Mind.Email))
            {
                register.Mind.RoleId = 1;
                _context.Minds.Add(register.Mind);
                _context.SaveChanges();

                register.CampusMind.MindId = register.Mind.Id;

                _context.CampusMinds.Add(register.CampusMind);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUserEmail(string Email)
        {
            // SelectedUser user = _context.SelectedUsers.Where(m => m.EmailId.Equals(Email)).FirstOrDefault();
            SelectedUser user = _context.SelectedUsers.FirstOrDefault(m => m.EmailId.Equals(Email));
            Mind mind = _context.Minds.Where(m => m.Email.Equals(Email)).FirstOrDefault();
            if (user != null && mind == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
