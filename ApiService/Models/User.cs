using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLogin.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FullName  { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
