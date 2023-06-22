using Backend.Entities;

const string GetTaskEndpointName = "GetTask";


List<TodoTask> todoTasks = new()
{
    new TodoTask ()
    {
        Id = Guid.NewGuid(),
        TaskName = "First Task Name",
        Discription = "First Task Discription",


    },
    new TodoTask ()
    {
        Id = Guid.NewGuid(),
        TaskName = "Second Task Name",
        Discription = "Second Task Discription",



    },
    new TodoTask ()
    {
        Id = Guid.NewGuid(),
        TaskName = "Tird Task Name",
        Discription = "Tird Task Discription",

    }
};

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
var app = builder.Build();

var group = app.MapGroup("/tasks");

app.UseCors("AllowAllOrigins");

group.MapGet("/", () => todoTasks);

group.MapGet("/{id}", (Guid id) =>
{
    TodoTask? task = todoTasks.Find(task => task.Id == id);

    if (task is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(task);
})
.WithName(GetTaskEndpointName);

group.MapPost("/", (TodoTask task) =>
{
    task.Id = Guid.NewGuid();
    todoTasks.Add(task);

    return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
});

group.MapPut("/{id}", (Guid  id, TodoTask updatedTask) =>
{
    TodoTask? existingTask = todoTasks.Find(task => task.Id == id);

    if (existingTask is null)
    {
        return Results.NotFound();
    }

    existingTask.TaskName = updatedTask.TaskName;
    existingTask.Discription = updatedTask.Discription;

    return Results.NoContent();
});

group.MapDelete("/{id}", (Guid id) =>
{
    TodoTask? task = todoTasks.Find(task => task.Id == id);

    if (task is not null)
    {
        todoTasks.Remove(task);
    }

    return Results.NoContent();
});

app.Run();
