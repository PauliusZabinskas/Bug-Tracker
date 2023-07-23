namespace BugTracker.Backend.Models;
public class TaskItem
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public string? Description { get; set; }
    public Guid CreatedBy { get; set; }

}