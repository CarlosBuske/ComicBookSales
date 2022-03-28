using Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Class.Identity
{
    public class SeedUserRoleInitial : ISeedRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            var defaultUserNotFound = _userManager.FindByEmailAsync("user@local.com").Result == null;
            if (defaultUserNotFound)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "Default User",
                    Email = "user@local.com",
                    NormalizedUserName = "DEFAULT USER",
                    NormalizedEmail = "USER@LOCAL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),

                };

                IdentityResult result = _userManager.CreateAsync(user, "Defaultpassword@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            var defaultAdminNotFound = _userManager.FindByEmailAsync("admin@local.com").Result == null;
            if (defaultAdminNotFound)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "Default Admin",
                    Email = "admin@local.com",
                    NormalizedUserName = "DEFAULT ADMIN",
                    NormalizedEmail = "ADMIN@LOCAL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),

                };

                IdentityResult result = _userManager.CreateAsync(user, "Defaultpassword@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            var defaultUserRoleNotFound = _roleManager.RoleExistsAsync("User").Result;
            if (!defaultUserRoleNotFound)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            var defaultAdminRoleNotFound = _roleManager.RoleExistsAsync("Admin").Result;
            if (!defaultAdminRoleNotFound)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        
    }
}
