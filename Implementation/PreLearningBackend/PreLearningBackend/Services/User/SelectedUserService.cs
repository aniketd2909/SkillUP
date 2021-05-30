﻿using PreLearningBackend.Context;
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
        public  bool AddUser(SelectedUser selectedUser)
        {
           _context.SelectedUsers.Add(selectedUser);
            int check =  _context.SaveChanges();
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public  bool DeleteUser(int Id)
        {
            bool flag = true;
            SelectedUser user = _context.SelectedUsers.Find(Id);
            if (user == null)
            {
                throw new UserNotFoundException("Selected User Not Present To Delete");
            }
            else
            {
                _context.SelectedUsers.Remove(user);
                int check =  _context.SaveChanges();
                if (check <= 0)
                {
                    flag = false;
                }

            }
            return flag;

        }

        public SelectedUser GetUserById(int Id)
        {
            SelectedUser user = _context.SelectedUsers.Find(Id);
            if (user == null)
            {
                throw new UserNotFoundException("User Not Found");
            }
            else
            {
                return user;
            }
        }

        public bool UpdateUser(SelectedUser selectedUser)
        {

            _context.SelectedUsers.Update(selectedUser);
            int check = _context.SaveChanges();
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
