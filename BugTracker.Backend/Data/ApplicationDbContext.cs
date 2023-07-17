using BugTracker.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Backend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Bug> Bugs { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
}