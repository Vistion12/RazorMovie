using Microsoft.AspNetCore.Identity;
using RazorMovie.Model;

namespace RazorMovie.Core;

public class Seed
{
    public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using var applicationServices = applicationBuilder.ApplicationServices.CreateScope();
        var roleManager= applicationServices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if(!await roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        }
        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        var UserManager = applicationServices.ServiceProvider.GetRequiredService<UserManager<User>>();
        string adminEmail = "n89190245729@gmail.com";
        var adminuser = await UserManager.FindByEmailAsync(adminEmail);

        if (adminuser is null) 
        {
            var user = new User
            {
                UserName = "Vistion12",
                Email = adminEmail,
                EmailConfirmed = true
            };

            await UserManager.CreateAsync(user, "Qwerty@123?");
            await UserManager.AddToRoleAsync(user, UserRoles.Admin);
        }

        string userEmail = "keke@gmail.com";
        var simpleuser = await UserManager.FindByEmailAsync(userEmail);

        if (simpleuser is null)
        {
            var newuser = new User
            {
                UserName = "qweqwe",
                Email = userEmail,
                EmailConfirmed = true
            };

            await UserManager.CreateAsync(newuser, "Qwerty@123333333?");
            await UserManager.AddToRoleAsync(newuser, UserRoles.User);
        }
    }
}
