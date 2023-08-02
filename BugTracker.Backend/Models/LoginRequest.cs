namespace BugTracker.Backend.Models;

public class LoginRequest
{
    public string username { get; set; }
    public string Password { get; set; }
    public bool Remember { get; set; }
}