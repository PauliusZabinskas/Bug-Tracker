using BugTracker.Backend.Data;
using BugTracker.Backend.Services;
using Microsoft.EntityFrameworkCore;
namespace BugTracker.Backend.Models;

public class CurrentUser<T> : ICurrentUser<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public CurrentUser(ApplicationDbContext context)
    {
        _context =  context;
    }

    

    

    public async Task<T?> GetUser(Guid id)
    {
       T currentUser = await _context.Set<T>().FindAsync(id);
        
        return currentUser;
    }

    
}