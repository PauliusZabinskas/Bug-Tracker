using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;



public class TodoTask
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string TaskName { get; set; }
    public required string Discription { get; set; }
    public TaskState CurrentState { get; set; } = TaskState.Open;
    [Required] 
    public string CreatedBy { get; set; } = "Default Paulius";
    
    // public decimal Reward { get; set; } = 20;

}