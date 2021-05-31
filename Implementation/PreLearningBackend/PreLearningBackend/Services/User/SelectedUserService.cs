using PreLearningBackend.Context;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public class SelectedUserService : ISelectedUserService
    {
        private readonly AppDbContext _context;
        public SelectedUserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(SelectedUser selectedUser)
        {
          await _context.SelectedUsers.AddAsync(selectedUser);
            int check = await  _context.SaveChangesAsync();
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async  Task<bool> DeleteUser(int Id)
        {
            bool flag = true;
            SelectedUser user = await _context.SelectedUsers.FindAsync(Id);
            if (user == null)
            {
                throw new UserNotFoundException("Selected User Not Present To Delete");
            }
            else
            {
                _context.SelectedUsers.Remove(user);
                int check =  await _context.SaveChangesAsync();
                if (check <= 0)
                {
                    flag = false;
                }

            }
            return flag;

        }

        public async Task<SelectedUser> GetUserById(int Id)
        {
            SelectedUser user = await _context.SelectedUsers.FindAsync(Id);
            if (user == null)
            {
                throw new UserNotFoundException("User Not Found");
            }
            else
            {
                return user;
            }
        }

        public async Task<bool> UpdateUser(SelectedUser selectedUser)
        {

            _context.SelectedUsers.Update(selectedUser);
            int check = await _context.SaveChangesAsync();
            if (check > 0)
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
