using System.Reflection;
using Backend.Auth;
using Backend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class TodoTaskContext : IdentityDbContext<ApplicationUser>
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