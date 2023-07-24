using BugTracker.Backend.Data;
using BugTracker.Backend.Services;
using Microsoft.EntityFrameworkCore;
namespace BugTracker.Backend.Models;

public class CurrentUser 
{
    private readonly ICurrentUser _currentUser;
    string? currentUserId;

    public CurrentUser( ICurrentUser currentUser)
    {
        _currentUser = currentUser;
         
    }


    public string? GetUser()
    {
        currentUserId = "a44fa732-8d0a-4808-b890-5a162242dcb3";
        return currentUserId;
    }

    
}