using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.User
{
    public interface ISelectedUserService
    {
        bool AddUser(SelectedUser selectedUser);
        SelectedUser GetUserById(int Id);

        bool DeleteUser(int Id);

        bool UpdateUser(SelectedUser selectedUser);
    }
}
