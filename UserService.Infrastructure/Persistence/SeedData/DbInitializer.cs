using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Infrastructure.Entities;

public static class DbInitializer
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // 1. Tạo Roles
        string[] roleNames = { "SuperAdmin", "Basic" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 2. Tạo User SuperAdmin
        var adminUser = new ApplicationUser { UserName = "superadmin", Email = "thinh48691953@gmail.com"};
        if (await userManager.FindByEmailAsync(adminUser.Email) == null)
        {
            var result = await userManager.CreateAsync(adminUser, "admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "SuperAdmin");
            }
        }

        // 3. Tạo User Basic
        var basicUser = new ApplicationUser { UserName = "basicuser", Email = "nguyenngocthinhtest@gmail.com"};
        if (await userManager.FindByEmailAsync(basicUser.Email) == null)
        {
            var result = await userManager.CreateAsync(basicUser, "user@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(basicUser, "Basic");
            }
        }
    }
}
