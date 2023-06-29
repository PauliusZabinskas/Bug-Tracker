using Backend.Entities;

namespace Backend.Repositories;

public class InMemTasksRepo : ITasksRepo
{
    private readonly List<TodoTask> todoTasks = new()
    {
        new TodoTask ()
        {
            Id = Guid.NewGuid(),
            TaskName = "First Task Name",
            Discription = "First Task Discription",
            CurrentState = TaskState.Open

        },
        new TodoTask ()
        {
            Id = Guid.NewGuid(),
            TaskName = "Second Task Name",
            Discription = "Second Task Discription",
            CurrentState = TaskState.Open


        },
        new TodoTask ()
        {
            Id = Guid.NewGuid(),
            TaskName = "Tird Task Name",
            Discription = "Tird Task Discription",
            CurrentState = TaskState.Open
        }
    };

    public async Task<IEnumerable<TodoTask>> GetAll()
    {
        return await Task.FromResult(todoTasks);
    }

    public async Task<TodoTask?> GetAsync(Guid id) // ? <= might return null
    {
        return await Task.FromResult(todoTasks.Find(task => task.Id == id));
    }

    public async Task CreateAsync(TodoTask task)
    {
        task.Id = Guid.NewGuid();
        todoTasks.Add(task);
        
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(TodoTask updatedTask)
    {
        var index = todoTasks.FindIndex(tasks => tasks.Id == updatedTask.Id);
        todoTasks[index] = updatedTask;

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var index = todoTasks.FindIndex(tasks => tasks.Id == id);
        todoTasks.RemoveAt(index);

        await Task.CompletedTask;
    }
}