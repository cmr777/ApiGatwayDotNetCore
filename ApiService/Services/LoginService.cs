using ApiLogin.Helpers;
using ApiLogin.Models;
using ApiLogin.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiLogin.Services
{
    public class LoginService : ILoginService
    {
        private List<User> _users = new List<User>
        {
            new User { UserId = 1, Address = "Ahmedabd", PhoneNo = "9067407001", FullName = "Simon Peter", Username = "good", Password = "test@123" },
            new User { UserId = 2, Address = "Vastral", PhoneNo = "9067407002", FullName = "Glen Woodhouse", Username = "pretty", Password = "test@123" },
            new User { UserId = 3, Address = "Gandhinagar", PhoneNo = "9067407003", FullName = "John Smith", Username = "nice", Password = "test@123" },
        };

        private readonly AppSettings _appSettings;
        private readonly ILoginRepository _login;

        public LoginService(IOptions<AppSettings> appSettings, ILoginRepository login)
        {
            _appSettings = appSettings.Value;
            _login = login;
        }
       

        public Models.SecurityToken Authenticate(string username, string password)
        {
            var user = _login.CheckLogin(username,password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid", user.UserId.ToString()),
                    new Claim("name", user.FullName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new Models.SecurityToken() { auth_token = jwtSecurityToken };
        }

    }
}
