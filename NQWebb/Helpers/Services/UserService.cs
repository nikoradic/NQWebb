using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NQWebb.Data;
using NQWebb.Models.ViewModels;

namespace NQWebb.Helpers.Services
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<bool> CreateUserAsync(UserRegistartionVM vM)
        {
            try
            {
                if (!await _roleManager.Roles.AnyAsync())
                {
                    await _roleManager.CreateAsync(new IdentityRole("administrator"));
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }

                var standardRole = "user";

                if (!await _userManager.Users.AnyAsync())
                {
                    standardRole = "administrator";
                }

                var identityUser = new IdentityUser
                {
                    UserName = vM.Email,
                    Email = vM.Email
                };

                var result = await _userManager.CreateAsync(identityUser, vM.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, standardRole);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> SignInAsync(UserLoginVM userLoginVM)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginVM.Email, userLoginVM.Password, false, false);
                return result.Succeeded;

            }
            catch { return false; }
        }

    }
}
