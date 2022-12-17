using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace MoneyApp.Server.Data;

public class SeedDefaultAdmin
{
    private static readonly string AdminRole = "Admin";
    private static readonly string UserRole = "User";
    private static readonly string AdminEmail = "admin@admin.com";
    private static readonly string UserEmail = "user@user.com";
    private static readonly string Password = "P@ssw0rd";

    internal static async Task CreateDefaultAdminAndUserWithRoles(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        bool adminRoleExist = await roleManager.RoleExistsAsync(AdminRole);
        bool userRoleExist = await roleManager.RoleExistsAsync(UserRole);

        if (adminRoleExist == false)
        {
            var role = new IdentityRole
            {
                Name = AdminRole,
            };

            await roleManager.CreateAsync(role);
        }

        if (userRoleExist == false)
        {
            var role = new IdentityRole
            {
                Name = UserRole,
            };

            await roleManager.CreateAsync(role);
        }

        bool adminExist = await userManager.FindByEmailAsync(AdminEmail) != null;
        bool userExist = await userManager.FindByEmailAsync(UserEmail) != null;

        if (adminExist == false)
        {
            var adminUser = new IdentityUser
            {
                UserName = AdminEmail,
                Email = AdminEmail
            };

            IdentityResult identityResult = await userManager.CreateAsync(adminUser, Password);

            if (identityResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, AdminRole);
            }
        }
        if (userRoleExist == false)
        {
            var user = new IdentityUser
            {
                UserName = UserEmail,
                Email = UserEmail
            };

            IdentityResult identityResult = await userManager.CreateAsync(user, Password);

            if (identityResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, UserRole);
            }
        }
    }
}
