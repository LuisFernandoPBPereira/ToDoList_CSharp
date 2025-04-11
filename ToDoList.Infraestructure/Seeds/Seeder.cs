using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Infraestructure.Seeds;

public class Seeder
{
    public static async Task SeedRoles(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Comum));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin));
    }
}
