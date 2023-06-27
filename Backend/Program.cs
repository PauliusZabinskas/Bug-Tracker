using Backend.Endpoints;
using Backend.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITasksRepo, InMemTasksRepo>();
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

app.UseCors("AllowAllOrigins");
app.MapTasksEndpoints();



app.Run();
