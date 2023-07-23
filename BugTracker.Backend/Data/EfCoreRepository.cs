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
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Create(T entity, Guid id)
    {
        
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
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

    public async Task<IEnumerable<T>> GetAll(int? page, int? limit)
    {
        // IEnumerable<T> entities = await _context.Set<T>().ToListAsync();
        // IEnumerable<T> entities = await _context.Set<T>()
        // .AsQueryable()
        // .Skip(page.Value)
        // .Take(limit.Value)
        // .ToListAsync();

        IQueryable<T> entities = _context.Set<T>().AsQueryable();

        if (page != null)
        {
            entities = entities.Skip(page.Value);
        }

        if (limit != null)
        {
            entities = entities.Take(limit.Value);
        }

        IEnumerable<T> filteredEntities = await entities.ToListAsync();

        return filteredEntities;
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    // added Guid for user Id. Will wait for constructive critisism {tension is on}
    public async Task<T?> GetByGuid(Guid id)
    {
        T entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task DeleteByGuid(Guid id)
    {
        T entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    
}

