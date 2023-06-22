namespace Backend.Entities;

public class TodoTask
{
    public Guid  Id { get; set; }
    public required string TaskName { get; set; } 
    public required string Discription { get; set; }
    
}