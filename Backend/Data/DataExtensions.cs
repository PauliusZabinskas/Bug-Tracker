using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public static class DataExtensions
{
    public static void IitializeDb (this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TodoTaskContext>();
        dbContext.Database.Migrate();
    }
}