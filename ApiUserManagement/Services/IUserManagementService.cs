using ApiUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUserManagement.Services
{
    public interface IUserManagementService
    {
        List<User> GetAllUser();
        User GetUserByUserId(int userId);
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
    }
}
