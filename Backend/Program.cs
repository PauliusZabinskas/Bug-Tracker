using Backend.Entities;

const string GetTaskEndpointName = "GetTask";


List<TodoTask> todoTasks = new()
{
    new TodoTask ()
    {
        Id = 1,
        TaskName = "First Task Name",
        Discription = "First Task Discription",


    },
    new TodoTask ()
    {
        Id = 2,
        TaskName = "Second Task Name",
        Discription = "Second Task Discription",



    },
    new TodoTask ()
    {
        Id = 3,
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

app.UseCors("AllowAllOrigins");

app.MapGet("/tasks", () => todoTasks);

app.MapGet("/tasks/{id}", (int id) =>
{
    TodoTask? task = todoTasks.Find(task => task.Id == id);

    if (task is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(task);
})
.WithName(GetTaskEndpointName);

app.MapPost("/tasks", (TodoTask task) =>
{
    task.Id = todoTasks.Max(task => task.Id) + 1;
    todoTasks.Add(task);

    return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
});

app.MapPut("/tasks/{id}", (int id, TodoTask updatedTask) =>
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

app.MapDelete("/tasks/{id}", (int id) =>
{
    TodoTask? task = todoTasks.Find(task => task.Id == id);

    if (task is not null)
    {
        todoTasks.Remove(task);
    }

    return Results.NoContent();
});

app.Run();
