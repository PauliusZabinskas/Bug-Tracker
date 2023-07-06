using Backend.Auth;
using Backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AccountAuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountAuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto model)
    {
        var user = new ApplicationUser
        {
            UserName = model.UserName,
            FullName = model.FullName, // assuming FullName is a property of RegisterUserDto
            Role = model.Role,
            // Add additional fields here.
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }

        // If we got this far, something failed, return error response
        return BadRequest(result.Errors);
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Ok();
        }

        // If we got this far, something failed, return error response
        return Unauthorized();
    }


}
