using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CSC578Final.Controllers
{
    using CSC578Final.Models;
    using CSC578Final.ViewModels;

    using Microsoft.AspNet.Identity;

    public class AccountController : Controller
    {
        private SignInManager<BlogUser> signInManager;

        public AccountController(SignInManager<BlogUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Posts", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                var signInResult = await this.signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);
                

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl)) return this.RedirectToAction("Posts", "Home");
                    return this.Redirect(returnUrl);
                }
                else
                {
                    this.ModelState.AddModelError("", "Username or password incorrect");
                }
            }

            return this.View();
        }
    }
}
