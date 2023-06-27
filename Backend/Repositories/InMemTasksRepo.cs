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

    public IEnumerable<TodoTask> GetAll()
    {
        return todoTasks;
    }

    public TodoTask? Get(Guid id) // ? <= might return null
    {
        return todoTasks.Find(task => task.Id == id);
    }

    public void Create(TodoTask task)
    {
        task.Id = Guid.NewGuid();
        todoTasks.Add(task);
    }

    public void Update(TodoTask updatedTask)
    {
        var index = todoTasks.FindIndex(tasks => tasks.Id == updatedTask.Id);
        todoTasks[index] = updatedTask;
    }

    public void Delete(Guid id)
    {
        var index = todoTasks.FindIndex(tasks => tasks.Id == id);
        todoTasks.RemoveAt(index);
    }
}