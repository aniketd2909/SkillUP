using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public interface ISelectedUserService
    {
        Task<bool> AddUser(SelectedUser selectedUser);
        Task<SelectedUser> GetUserById(int Id);

        Task<bool> DeleteUser(int Id);

       Task<bool> UpdateUser(SelectedUser selectedUser);
    }
}
