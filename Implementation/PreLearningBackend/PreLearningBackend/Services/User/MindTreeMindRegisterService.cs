using PreLearningBackend.Context;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public class MindTreeMindRegisterService : IMindTreeMindRegisterService
    {
        private readonly AppDbContext _context;
        public MindTreeMindRegisterService(AppDbContext context)
        {
            _context = context;
        }
        public bool AddDetails(MindTreeMindRegister mindTreeMindDetails)
        {
            if (validateMindTreeMind(mindTreeMindDetails.Mind.Email))
            {
                mindTreeMindDetails.Mind.RoleId = 2;
                _context.Minds.Add(mindTreeMindDetails.Mind);
                _context.SaveChanges();

                mindTreeMindDetails.MindTreeMind.MindId = mindTreeMindDetails.Mind.Id;

                _context.MindTreeMinds.Add(mindTreeMindDetails.MindTreeMind);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validateMindTreeMind(string Email)
        {
            Mind mind = _context.Minds.Where(m => m.Email.Equals(Email)).FirstOrDefault();
            if (mind == null)
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
