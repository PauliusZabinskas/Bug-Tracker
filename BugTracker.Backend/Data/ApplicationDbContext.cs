using BugTracker.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BugTracker.Backend.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<BugIssue> Bugs { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
}