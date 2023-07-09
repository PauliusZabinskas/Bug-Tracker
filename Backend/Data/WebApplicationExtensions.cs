using Backend.Data;

public static class WebApplicationExtensions
{
    public static async Task InitializeDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TodoTaskContext>();

        // Perform any necessary database initialization tasks here
        // For example, seeding initial data

        await dbContext.SaveChangesAsync();
    }
}