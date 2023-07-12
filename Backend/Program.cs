using Backend.Auth;
using Backend.Data;
using Backend.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;  // for IServiceScopeFactory

var builder = WebApplication.CreateBuilder(args);
// Ensure you have defined AddRepositories somewhere in your code
builder.Services.AddRepositories(builder.Configuration);

// Add Identity services to the services container.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    // set other options as needed
})
    .AddEntityFrameworkStores<TodoTaskContext>()
    .AddDefaultTokenProviders();

// Add Authorization services.
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Create a new scope to retrieve scoped services
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TodoTaskContext>();
    await context.InitializeDbAsync(); // Ensure you have defined InitializeDbAsync somewhere in your code
}

app.UseAuthentication(); // Use Authentication
app.UseAuthorization(); // Use Authorization

app.UseCors("AllowAllOrigins");
// Ensure you have defined MapTasksEndpoints somewhere in your code
app.MapTasksEndpoints();
// Ensure you have defined MapAuthEndpoints somewhere in your code
app.MapAuthEndpoints();

app.Run();
