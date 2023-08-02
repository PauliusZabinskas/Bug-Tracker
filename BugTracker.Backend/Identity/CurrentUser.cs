using System.Net.NetworkInformation;
using System.Security.Claims;
using BugTracker.Backend.Services;
namespace BugTracker.Backend.Models;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    public string? GetUser()
    {
        string? userId = _httpContextAccessor
        .HttpContext?
        .User?
        .FindFirst(ClaimTypes.NameIdentifier)?
        .Value;
        
        return userId;
    }
}