using Microsoft.AspNetCore.Identity;

namespace Backend.Auth;

public class ApplicationUser : IdentityUser
{
    

    public required string FullName { get; set; }
    public required string Role { get; set; }
}