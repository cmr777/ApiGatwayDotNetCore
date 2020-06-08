
using ApiUserManagement.Models;
using ApiUserManagement.Repositories;
using ApiUserManagement.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserManagement.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository _userRepository;
        public UserManagementService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }

        public List<User> GetAllUser()
        {
           return _userRepository.GetAllUser();
        }

        public User GetUserByUserId(int userId)
        {
            return _userRepository.GetUserByUserId(userId);
        }

        public bool InsertUser(User user)
        {
           
            return _userRepository.InsertUser(user);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
