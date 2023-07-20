namespace BugTracker.Backend.Models;
public class User
{
    public Guid Id { get; set; }
    public string? UserFullName { get; set; } ="Paulius Zab";
    public string? Alias { get; set; } = "Ice-Criem-Lover";
    public string? EmailAddress { get; set; } = "Fake@gmail.com";
    public string? Password { get; set; } = "123456";

}