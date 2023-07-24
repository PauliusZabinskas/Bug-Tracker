using BugTracker.Backend.Models;

namespace BugTracker.Backend.Services;

public interface ICurrentUser
{
    string GetUser();
    // Task<T?> User(int id);
}