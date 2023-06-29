using Backend.Entities;

namespace Backend.Repositories;

public interface ITasksRepo
{
    Task CreateAsync(TodoTask task);
    Task DeleteAsync(Guid id);
    Task<TodoTask?> GetAsync(Guid id);
    Task<IEnumerable<TodoTask>> GetAll();
    Task UpdateAsync(TodoTask updatedTask);
}
