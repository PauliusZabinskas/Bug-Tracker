using BugTracker.Backend.Data;
using BugTracker.Backend.Models;
using BugTracker.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("devDb");
});

builder.Services.AddHttpClient();
builder.Services.AddIdentityCore<User>(options => {
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// when IRepository is asked - give EfCoreRepository of the same type
builder.Services.AddTransient(typeof(IUserManager<User>),typeof(UserManager<User>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
builder.Services.AddTransient(typeof(ICurrentUser), typeof(CurrentUser));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
