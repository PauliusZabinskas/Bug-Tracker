using System.ComponentModel.DataAnnotations;
using Backend.Entities;

namespace Backend.Dtos;



public record TodoTaskDto (
    Guid Id,
    string TaskName,
    string Discription,
    TaskState CurrentState
);

public record CreateTodoTaskDto(
    Guid Id,
    [Required][StringLength(100)] string TaskName,
    [Required] string Discription,
    TaskState CurrentState
);

public record UpdateTodoTaskDto(
    Guid Id,
    [Required][StringLength(100)] string TaskName,
    [Required] string Discription,
    TaskState CurrentState
);
