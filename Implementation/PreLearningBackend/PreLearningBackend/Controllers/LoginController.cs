using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.JWTAuthenticationManager;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTAuthentication _jWTAuthentication;

        public LoginController(IJWTAuthentication jWTAuthentication)
        {
            _jWTAuthentication = jWTAuthentication;
        }

        // POST api/<LoginController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
            var token = _jWTAuthentication.Login(userCredential.Email, userCredential.Password);
            if (token is null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
