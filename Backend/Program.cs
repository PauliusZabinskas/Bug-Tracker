using Backend.Data;
using Backend.Endpoints;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITasksRepo, InMemTasksRepo>();

var connString = builder.Configuration.GetConnectionString("TodoTaskContext");
builder.Services.AddSqlServer<TodoTaskContext>(connString);

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

app.Services.IitializeDb();

app.UseCors("AllowAllOrigins");
app.MapTasksEndpoints();



app.Run();
