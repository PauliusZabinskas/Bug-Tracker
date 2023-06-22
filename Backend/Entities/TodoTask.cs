using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public class TodoTask
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string TaskName { get; set; } 
    public required string Discription { get; set; }
    
}