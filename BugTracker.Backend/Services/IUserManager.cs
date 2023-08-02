using System.Security.Claims;
using BugTracker.Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Backend.Services;

public interface IUserManager<User>
{
    Task<User> RegisterAsync(RegisterRequest request);
    Task<User> LoginAsync(LoginRequest request);
    // Task<IdentityUser> HashPasswordAsync(LoginRequest request);
    // Task<IdentityResult> ChangePasswordAsync(IdentityUser user, string currentPassword, string newPassword);
    // Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role);
    // Task<IdentityResult> RemoveFromRoleAsync(IdentityUser user, string role);
    // Task<IList<Claim>> GetClaimsAsync(IdentityUser user);
    // Task<IdentityResult> AddClaimAsync(IdentityUser user, Claim claim);
    // Task<IdentityResult> RemoveClaimAsync(IdentityUser user, Claim claim);
}