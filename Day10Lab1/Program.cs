using Microsoft.EntityFrameworkCore;
using Day10Lab1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string cnString = builder.Configuration.GetConnectionString("sqlite");
builder.Services.AddDbContext<Day10Lab1.DataContext> (c=>c.UseSqlite (cnString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapToDoItemEndpoints();

app.Run();
