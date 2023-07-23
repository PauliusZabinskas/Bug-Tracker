using BugTracker.Backend.Models;

namespace BugTracker.Backend.Services;

public interface ICurrentUser<T>
{
    Task<T?> GetUser(Guid id);
    // Task<T?> User(int id);
}