using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public static class DataExtensions
{
    public static async Task IitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TodoTaskContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration conficuration
    )
    {
        var connString = conficuration.GetConnectionString("TodoTaskContext");
        services.AddSqlServer<TodoTaskContext>(connString).AddScoped<ITasksRepo, EntityFrameworkTodoTaskRepository>(); ;

        return services;
    }
}