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

        group.MapGet("/", (ITasksRepo repository) => repository.GetAll());

        group.MapGet("/{id}", (ITasksRepo repository, Guid id) =>
        {
            TodoTask? task = repository.Get(id);
            return task is not null ? Results.Ok(task) : Results.NotFound();

        })
        .WithName(GetTaskEndpointName);

        group.MapPost("/", (ITasksRepo repository, TodoTask task) =>
        {
            repository.Create(task);

            return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
        });

        group.MapPut("/{id}", (ITasksRepo repository, Guid  id, TodoTask updatedTask) =>
        {
            TodoTask? existingTask = repository.Get(id);

            if (existingTask is null)
            {
                return Results.NotFound();
            }

            existingTask.TaskName = updatedTask.TaskName;
            existingTask.Discription = updatedTask.Discription;
            existingTask.CurrentState = updatedTask.CurrentState;

            repository.Update(existingTask);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (ITasksRepo repository, Guid id) =>
        {
            TodoTask? task = repository.Get(id);

            if (task is not null)
            {
                repository.Delete(id);
            }

            return Results.NoContent();
        });
        return group;
    }

}