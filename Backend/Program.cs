using Backend.Endpoints;


var builder = WebApplication.CreateBuilder(args);
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
