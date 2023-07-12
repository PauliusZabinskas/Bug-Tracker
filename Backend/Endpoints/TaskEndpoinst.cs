using Backend.Dtos;
using Backend.Entities;
using Backend.Repositories;

namespace Backend.Endpoints;

public static class TaskEndpoinst
{
    const string GetTaskEndpointName = "GetTask";

    public static RouteGroupBuilder MapTasksEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/tasks")
        .WithParameterValidation();

        group.MapGet("/", async (ITasksRepo repository) =>
        (await repository.GetAllAsync()).Select(task => task.AsDto())).RequireAuthorization();

        group.MapGet("/{id}", async (ITasksRepo repository, Guid id) =>
        {
            TodoTask? task = await repository.GetAsync(id);
            return task is not null ? Results.Ok(task.AsDto()) : Results.NotFound();

        })
        .WithName(GetTaskEndpointName)
        .RequireAuthorization();

        group.MapPost("/", async (ITasksRepo repository, CreateTodoTaskDto taskDto) =>
        {
            TodoTask task = new()
            {
                TaskName = taskDto.TaskName,
                Discription = taskDto.Discription,
                CurrentState = taskDto.CurrentState,
                CreatedBy = taskDto.CreatedBy
                // Reward = taskDto.Reward
            };

            await repository.CreateAsync(task);
            return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
        }).RequireAuthorization();

        group.MapPut("/{id}", async (ITasksRepo repository, Guid id, UpdateTodoTaskDto updatedTaskDto) =>
        {
            TodoTask? existingTask = await repository.GetAsync(id);

            if (existingTask is null)
            {
                return Results.NotFound();
            }

            existingTask.TaskName = updatedTaskDto.TaskName;
            existingTask.Discription = updatedTaskDto.Discription;
            existingTask.CurrentState = updatedTaskDto.CurrentState;
            existingTask.CreatedBy = updatedTaskDto.CreatedBy;
            // existingTask.Reward = updatedTaskDto.Reward;

            await repository.UpdateAsync(existingTask);

            return Results.NoContent();
        }).RequireAuthorization();

        group.MapDelete("/{id}", async (ITasksRepo repository, Guid id) =>
        {
            TodoTask? task = await repository.GetAsync(id);

            if (task is not null)
            {
                await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        }).RequireAuthorization();
      
        return group;
    }

}