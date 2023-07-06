using Backend.Auth;
using Backend.Data;
using Backend.Endpoints;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

// Add Identity services to the services container.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TodoTaskContext>()
    .AddDefaultTokenProviders();

// Add Authentication services.
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    });

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

await app.Services.IitializeDbAsync();

app.UseAuthentication(); // Use Authentication
app.UseAuthorization(); // Use Authorization

app.UseCors("AllowAllOrigins");
app.MapTasksEndpoints();

app.Run();
