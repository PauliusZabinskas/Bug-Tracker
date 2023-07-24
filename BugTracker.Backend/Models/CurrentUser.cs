using BugTracker.Backend.Data;
using BugTracker.Backend.Services;
using Microsoft.EntityFrameworkCore;
namespace BugTracker.Backend.Models;

public class CurrentUser : ICurrentUser
{
    
    string? currentUserId;

    public CurrentUser( )
    {
        
    }


    public string? GetUser()
    {
        currentUserId = "a44fa732-8d0a-4808-b890-5a162242dcb3";
        return currentUserId;
    }

    
}