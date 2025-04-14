using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Infraestructure.Data;
using ToDoList.Infraestructure.Entities;

namespace ToDoList.Infraestructure.Seeds;

public class Seeder
{
    public static async Task SeedRoles(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Comum));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin));
    }

    public static async Task SeedAdmin(IServiceProvider services)
    {
        var context = services.GetRequiredService<ToDoListContext>();
        var userManager = services.GetRequiredService<UserManager<UsuarioIdentity>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var adminUser = await context.Users.FirstOrDefaultAsync(user => user.UserName == "AdminUser");

        if (adminUser is null)
        {
            adminUser = new UsuarioIdentity
            {
                UserName = "AdminUser",
                Email = "AdminUser@exemplo.com"
            };
        
            await userManager.CreateAsync(adminUser, "*Admin123");
            await userManager.AddToRoleAsync(adminUser, Roles.Admin);
        }
    }
}
