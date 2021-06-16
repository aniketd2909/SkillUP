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
        public async Task<bool> AddDetails(MindTreeMindRegister register)
        {



            if (validateMindTreeMind(register.Email))
            {
                Mind mind = new Mind();
                mind.ContactNo = register.ContactNo;
                mind.Email = register.Email;
                mind.Gender = register.Gender;
                mind.Name = register.Name;
                mind.RoleId = register.RoleId;
                mind.Password = register.Password;

                MindTreeMind mindTreeMind = new MindTreeMind();

                mindTreeMind.Location = register.Location;
                mindTreeMind.Track = register.Track;



                await _context.Minds.AddAsync(mind);
                await _context.SaveChangesAsync();


                mindTreeMind.MindId = mind.Id;

                await _context.MindTreeMinds.AddAsync(mindTreeMind);
                await _context.SaveChangesAsync();
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
