using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class EntityFrameworkTodoTaskRepository : ITasksRepo
{
    private readonly TodoTaskContext dbContext;

    public EntityFrameworkTodoTaskRepository(TodoTaskContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<TodoTask>> GetAll()
    {
        return await dbContext.TodoTasks.AsNoTracking().ToListAsync();
    }

    public async Task<TodoTask?> GetAsync(Guid id)
    {
        return await dbContext.TodoTasks.FindAsync(id);
    }

    public async Task CreateAsync(TodoTask task)
    {
        dbContext.TodoTasks.Add(task);
        await dbContext.SaveChangesAsync();
    }


    public async Task UpdateAsync(TodoTask updatedTask)
    {
        dbContext.Update(updatedTask);
        await dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        await dbContext.TodoTasks.Where(task => task.Id == id).ExecuteDeleteAsync();
    }
}