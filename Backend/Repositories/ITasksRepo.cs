using Backend.Entities;

namespace Backend.Repositories;

public interface ITasksRepo
{
    void Create(TodoTask task);
    void Delete(Guid id);
    TodoTask? Get(Guid id);
    IEnumerable<TodoTask> GetAll();
    void Update(TodoTask updatedTask);
}
