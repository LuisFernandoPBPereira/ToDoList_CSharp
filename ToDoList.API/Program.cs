using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList;
using ToDoList.Infraestructure.Data;
using ToDoList.Infraestructure.Entities;
using ToDoList.Infraestructure.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();

var configuration = builder.Configuration;

builder.Services.AddDbContext<ToDoListContext>(options => options.UseSqlite(configuration.GetConnectionString("Database")));

builder.Services.AddIdentity<UsuarioIdentity, IdentityRole<Guid>>()
        .AddRoles<IdentityRole<Guid>>()
        .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
        .AddEntityFrameworkStores<ToDoListContext>()
        .AddDefaultTokenProviders();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await Seeder.SeedRoles(services);
}

app.Run();
