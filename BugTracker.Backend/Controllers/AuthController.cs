using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Backend.Controllers;

    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager<User> _userManager;

        // IUserManager service.
        public AuthController(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // required params:
        //  - username
        //  - password
        //  - rememberMe
        [HttpPost]
        public Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // authenticate
            // createToken
            // return token;
            throw new NotImplementedException();
        }

        // required:
        //  - username
        //  - password
        //  - email
        [HttpPost]
        public Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> ChangePassword()
        {
            throw new NotImplementedException();
        }

        // function CreateToken();
    }


