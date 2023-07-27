using BugTracker.Backend.Services;
namespace BugTracker.Backend.Models;

public class CurrentUser : ICurrentUser
{

    public CurrentUser( )
    {
        
    }


    public int? GetUser()
    {
        
        return 2;
    }
}