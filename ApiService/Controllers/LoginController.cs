using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLogin.Models;
using ApiLogin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService userService)
        {
            _loginService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult>  Authenticate(Login loginParam)
        {
            var token = await Task.Run(() => {
              return  _loginService.Authenticate(loginParam.Username, loginParam.Password);
            });
            
            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return   Ok(token); 
        }
    }
}