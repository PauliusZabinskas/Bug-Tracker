using BugTracker.Backend.Data;
using BugTracker.Backend.Services;
using Microsoft.EntityFrameworkCore;

public class EfCoreRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public EfCoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task Delete(int id)
    {
        T entity = await _context.Set<T>().FindAsync(id);

        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<T?> Get(int id)
    {
        T entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        IEnumerable<T> entities = await _context.Set<T>().ToListAsync();
        return entities;
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

}