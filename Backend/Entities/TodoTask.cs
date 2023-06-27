using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public enum TaskState
{
    Open = 1,
    InProcess = 2,
    Closed = 3
}

public class TodoTask
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string TaskName { get; set; } 
    public required string Discription { get; set; }
    public TaskState CurrentState { get; set; } = TaskState.Open;
    
}