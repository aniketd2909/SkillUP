using PreLearningBackend.Context;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        public RoleService(AppDbContext context)
        {
            _context = context;
        }
        /*public async Task<bool> AddRole(Role role)
       {
           _context.Roles.Add(role);
          int check = await _context.SaveChangesAsync();
           if(check >0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }*/
        public Role GetRole(int Id)
        {
            Role role =  _context.Roles.Find(Id);
            if (role == null)
            {
                throw new RoleNotFoundException("Role Not Found");
            }
            else
            {
                return role;
            }
        }
    }
}
