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
        public async Task<bool> AddDetails(CampusMindRegister register)
        {

            if (ValidateUserEmail(register.Email))
            {
                Mind mind = new Mind();
                mind.ContactNo = register.ContactNo;
                mind.Email = register.Email;
                mind.Gender = register.Gender;
                mind.Name = register.Name;
                mind.RoleId = register.RoleId;
                mind.Password = register.Password;

                CampusMind campusMind = new CampusMind();
                campusMind.EngineeringBranch = register.EngineeringBranch;
                await _context.Minds.AddAsync(mind);
                await _context.SaveChangesAsync();

                //register.CampusMind.MindId = register.Mind.Id;
                campusMind.MindId = mind.Id;
                await _context.CampusMinds.AddAsync(campusMind);
                await _context.SaveChangesAsync();
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
