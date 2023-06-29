using Backend.Data;
using Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

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

app.UseCors("AllowAllOrigins");
app.MapTasksEndpoints();



app.Run();
