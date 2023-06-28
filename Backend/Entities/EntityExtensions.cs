using Backend.Dtos;

namespace Backend.Entities;

public static class EntityExtensions
{
    public static TodoTaskDto AsDto(this TodoTask task)
    {
        return new TodoTaskDto(
            task.Id,
            task.TaskName,
            task.Discription,
            task.CurrentState
        );

    }
}