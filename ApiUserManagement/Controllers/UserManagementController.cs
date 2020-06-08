using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUserManagement.Models;
using ApiUserManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private IUserManagementService _userManagementService;
        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        // GET: api/UserManagement
        [HttpGet]
        [Route("Get")]
        public IEnumerable<User> Get()
        {
            return _userManagementService.GetAllUser() ;
        }

        // GET: api/UserManagement/5
        [HttpGet("{id}")]
        [Route("GetById")]
        public User Get(int id)
        {
            return _userManagementService.GetUserByUserId(id);
        }

        // POST: api/UserManagement
        [HttpPost]
        [Route("PostData")]
        public bool Post([FromBody] User value)
        {
            return _userManagementService.InsertUser(value);
        }

        // PUT: api/UserManagement/5
        [HttpPut("{id}")]
        [Route("PutData")]
        public bool Put(int id, [FromBody] User value)
        {
            return _userManagementService.UpdateUser(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("DeleteData")]
        public void Delete(int id)
        {
            _userManagementService.DeleteUser(id);
        }
    }
}
