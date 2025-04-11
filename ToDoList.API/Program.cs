using Microsoft.EntityFrameworkCore;
using ToDoList;
using ToDoList.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();

var configuration = builder.Configuration;

builder.Services.AddDbContext<ToDoListContext>(options => options.UseSqlite(configuration.GetConnectionString("Database")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
