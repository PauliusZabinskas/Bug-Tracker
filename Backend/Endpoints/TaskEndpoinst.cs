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
        (await repository.GetAll()).Select(task => task.AsDto()));

        group.MapGet("/{id}", async (ITasksRepo repository, Guid id) =>
        {
            TodoTask? task = await repository.GetAsync(id);
            return task is not null ? Results.Ok(task.AsDto()) : Results.NotFound();

        })
        .WithName(GetTaskEndpointName);

        group.MapPost("/", async (ITasksRepo repository, CreateTodoTaskDto taskDto) =>
        {
            TodoTask task = new()
            {
                TaskName = taskDto.TaskName,
                Discription = taskDto.Discription,
                CurrentState = taskDto.CurrentState
            };

            await repository.CreateAsync(task);
            return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
        });

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

            await repository.UpdateAsync(existingTask);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (ITasksRepo repository, Guid id) =>
        {
            TodoTask? task = await repository.GetAsync(id);

            if (task is not null)
            {
                await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        });
        return group;
    }

}