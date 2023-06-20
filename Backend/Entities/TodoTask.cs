namespace Backend.Entities;

public class TodoTask
{
    public int Id { get; set; }
    public required string TaskName { get; set; } 
    public required string Discription { get; set; }
    public DateTime ReleaseDate { get; set; }
    public required string ImageUrl { get; set; }
    
}