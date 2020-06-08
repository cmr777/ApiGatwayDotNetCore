using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUserManagement.Models;

namespace ApiUserManagement.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserByUserId(int userId);
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
    }
}
