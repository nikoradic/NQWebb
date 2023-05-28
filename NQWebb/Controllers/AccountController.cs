using Microsoft.AspNetCore.Mvc;
using NQWebb.Helpers.Services;
using NQWebb.Models.ViewModels;

namespace NQWebb.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserService userService;

        public AccountController(UserService userService)
        {
            this.userService = userService;
        }

        // Account
        public IActionResult Index()
        {
            return View();
        }

        // Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // Account/Register - POST
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistartionVM userRegistartionVM)
        {
            if (ModelState.IsValid)
            {
                if (await userService.CreateUserAsync(userRegistartionVM))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userRegistartionVM);
        }


        // Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // Account/Login - POST
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {

            if (ModelState.IsValid)
            {
                if (await userService.SignInAsync(userLoginVM))
                {
                    return RedirectToAction("Index", "Home");


                }
                ModelState.AddModelError("", "Wrong Email or Password");
            }
            return View(userLoginVM);


        }
    }
}
