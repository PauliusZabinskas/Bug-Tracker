namespace BugTracker.Backend.Services;

public interface IRepository<T>
{
    Task<T> Create(T entity);
    Task<T?> Get(int id);
    Task Update(T entity);
    Task Delete(int id);
    Task<IEnumerable<T>> GetAll();
}

