using Backend.Data;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{
    public static async Task InitializeDbAsync(this TodoTaskContext context)
    {
        // Example: Automatically migrate database
        await context.Database.MigrateAsync();
        
        // Add more database initialization logic as needed
    }
}
