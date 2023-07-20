using BugTracker.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Backend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<BugIssue> Bugs { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
}