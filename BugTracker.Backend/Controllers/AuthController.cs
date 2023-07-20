using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Backend.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<Auth> _repository;

        public AuthController(IRepository<Auth> repository)
        {
            _repository = repository;
        }

        // [HttpGet]
        // public async Task<IActionResult> Login()
        // {
            
        // }
    }
