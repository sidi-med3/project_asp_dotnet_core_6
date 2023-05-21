using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projet_dot_net_annonce.ViewModels;

namespace Projet_dot_net_annonce.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
         
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
     
        public async Task<IActionResult> Index()
        {
            var UsersList = new RgisterListViewMode
            {
                Users = _userManager.Users.ToList()
            };
            return View(UsersList);

        }
        public async Task<IActionResult> Delet(String id)
        {
            var user = await _userManager.FindByIdAsync(id);
            _userManager.DeleteAsync(user);
            

            return RedirectToAction("Index");

        }
        public IActionResult Registers()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registers(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Nom,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Accounts");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Result = await _signInManager.PasswordSignInAsync
                      (model.Email, model.Password, model.RememberMy, false);
                if (Result.Succeeded)
                {
                    return RedirectToAction("Index", "Userannonce");
                }
                ModelState.AddModelError(String.Empty, "Invalid Email Or Password");
            }
            return View(model);
        }

    }
}
