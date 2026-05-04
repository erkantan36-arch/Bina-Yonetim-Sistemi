using BinaDaireYonetim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BinaDaireYonetim.Data
{
    public static class SeedData
    {
        private const string AdminRoleName = "Admin";
        private const string YoneticiRoleName = "Yönetici";

        private const string AdminEmail = "admin@bina.com";
        private const string AdminPassword = "Admin123!";

        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Migrate database
            await dbContext.Database.MigrateAsync();

            // Create roles
            string[] roles = { AdminRoleName, YoneticiRoleName };
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                    await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Create default admin user
            if (await userManager.FindByEmailAsync(AdminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = AdminEmail,
                    Email = AdminEmail,
                    AdSoyad = "Sistem Yöneticisi",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, AdminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, AdminRoleName);
            }
        }
    }
}
