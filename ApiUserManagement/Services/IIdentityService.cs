using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUserManagement.Models;

namespace ApiUserManagement.Services
{
    public interface IIdentityService
    {
        IdentityModel GetIdentity();
    }
}
