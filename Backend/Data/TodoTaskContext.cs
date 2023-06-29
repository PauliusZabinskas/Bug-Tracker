using System.Reflection;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class TodoTaskContext : DbContext
{
    public TodoTaskContext(DbContextOptions<TodoTaskContext> options)
        : base(options)
    {
        
    }

    public DbSet<TodoTask> TodoTasks => Set<TodoTask>();

    // Can be used when decimal values are used in API
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    // }
}