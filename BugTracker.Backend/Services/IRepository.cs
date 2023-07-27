using System.Linq.Expressions;
using BugTracker.Backend.Models;

namespace BugTracker.Backend.Services;

public interface IRepository<T>
{
    Task<T> Create(T entity);
    Task<T?> Get(int id);
    Task Update(T entity);
    Task Delete(int id);
    Task<IEnumerable<T>> GetAll(int? page, int? limit);
    


    // this is the point where i would apreaciate to learn how to make     generic method to find item by id or by any other property.
    Task<T> GetByGuid(Guid id);
    Task DeleteByGuid(Guid id);
    Task<T?> FindBy(Func<T, bool> selector);
    Task<IEnumerable<T?>> FindManyBy(Func<T, bool> selector, int? page, int? limit);
    
    
}

