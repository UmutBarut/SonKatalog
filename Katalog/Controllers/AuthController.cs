using Microsoft.AspNetCore.Mvc;
using Katalog.Entity;
using Katalog.Dataaccess.Concrete.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Katalog.ViewModels;

namespace Katalog.Controllers
{
   [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signinManager;
        public AuthController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("User");
            ViewData["Title"] = "Çıkış yapılıyor...";
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewData["Title"] = "Panele Giriş";
            return View();
        }


         [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel p)
        {
            ViewData["LoginResult"] = "";
            ViewData["Title"] = "Giriş Yapılıyor";
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(p.UserName, p.Password, false, true);

                if (result.Succeeded)
                {
                    // Kullanıcının oturum açtığını doğrula
                    var user = await _userManager.FindByNameAsync(p.UserName);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData["LoginResult"] = "Kullanıcı adı veya şifre hatalı.";
                    return View(p);
                }
            }
            else
            {
                return View(p);
            }
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kullanıcı Kayıt";
            return View();
        }

         [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel p)
        {
            ViewData["Title"] = "Kayıt ediliyor..";
            if (ModelState.IsValid)
            {
                Kullanici user = new Kullanici()
                {
                    Email = p.Mail,
                    UserName = p.Username
                };
                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View(p);
        }
    }
}