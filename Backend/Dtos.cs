using System.ComponentModel.DataAnnotations;
using Backend.Entities;

namespace Backend.Dtos;



public record TodoTaskDto(
    Guid Id,
    string TaskName,
    string Discription,
    TaskState CurrentState,
    string createdBy
    // decimal Reward
    );

public record CreateTodoTaskDto(
    Guid Id,
    [Required][StringLength(100)] string TaskName,
    [Required] string Discription,
    TaskState CurrentState,
    string CreatedBy
    // decimal Reward
);

public record UpdateTodoTaskDto(
    Guid Id,
    [Required][StringLength(100)] string TaskName,
    [Required] string Discription,
    TaskState CurrentState,
    [Required] string CreatedBy
    // decimal Reward
);

public record RegisterUserDto (
    [Required][StringLength(20)] string UserName,
    [Required][StringLength(20)]string FullName,
    [Required][DataType(DataType.Password)] string Password,
    [Required] string Role
);
public record LoginDto (
    [Required][StringLength(20)] string UserName,
    [Required] string Password
);

public record ChangePasswordDto (
    [Required][DataType(DataType.Password)] string CurrentPassword,
    [Required][DataType(DataType.Password)] string NewPassword
);

public record ForgotPasswordRequestDto (
    [Required] string UserName
);

public record ResetPasswordDto (
    [Required][StringLength(20)] string UserName,
    [Required][DataType(DataType.Password)] string Token,
    [Required][DataType(DataType.Password)] string NewPassword
);
