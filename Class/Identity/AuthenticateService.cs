using Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private const int USER_TYPE = 1;
        private const int ADMIN_TYPE = 2;
        public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string name, string email, string password, int userType)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                var adminUserType = ADMIN_TYPE == userType;
                if (adminUserType)
                    _userManager.AddToRoleAsync(applicationUser, "Admin").Wait();
                else
                    _userManager.AddToRoleAsync(applicationUser, "User").Wait();

                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }

            return result.Succeeded;
        }

        public async Task<bool> UpdateUser(string idUser ,string name, string email, string password, int userType)
        {
            var applicationUser = new ApplicationUser
            {
                Id = idUser,
                UserName = email,
                Email = email,
            };

            var result = await _userManager.UpdateAsync(applicationUser);


            var user = await _userManager.FindByIdAsync(idUser);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resultPassword = await _userManager.ResetPasswordAsync(user, token, password);

            if (result.Succeeded && resultPassword.Succeeded)
            {
                var adminUserType = ADMIN_TYPE == userType;
                if (adminUserType)
                    _userManager.AddToRoleAsync(applicationUser, "Admin").Wait();
                else
                    _userManager.AddToRoleAsync(applicationUser, "User").Wait();

                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }

            var Success = result.Succeeded && resultPassword.Succeeded;

            return Success;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        
    }
}
