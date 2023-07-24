using BugTracker.Backend.Data;
using BugTracker.Backend.Services;
using Microsoft.EntityFrameworkCore;
namespace BugTracker.Backend.Models;

public class CurrentUser : ICurrentUser 
{
    private readonly ICurrentUser _currentUser;
    string? currentUser;

    public CurrentUser()
    {
     currentUser = "a44fa732-8d0a-4808-b890-5a162242dcb3";
    }


    public string? GetUser()
    {
        
        return currentUser;
    }

    
}