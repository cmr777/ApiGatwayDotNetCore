using ApiUserManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUserManagement.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IdentityModel GetIdentity()
        {
            string authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = authorizationHeader.Split(" ")[1];
                var paresedToken = tokenHandler.ReadJwtToken(token);

                var userid = paresedToken.Claims
                    .Where(c => c.Type == "userid")
                    .FirstOrDefault();

                var name = paresedToken.Claims
                    .Where(c => c.Type == "name")
                    .FirstOrDefault();

               
                return new IdentityModel()
                {
                    UserId = Convert.ToInt32(userid.Value),
                    FullName = name.Value,
                   
                };
            }

            throw new ArgumentNullException("userid");
        }
    }
}
