using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLogin.Models;

namespace ApiLogin.Repositories
{
    public interface ILoginRepository
    {
 
        User CheckLogin(string username, string password);
     
    }
}
