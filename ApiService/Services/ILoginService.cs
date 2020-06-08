using ApiLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLogin.Services
{
    public interface ILoginService
    {
        SecurityToken Authenticate(string username, string password);
    }
}
