using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Katalog.Business.Abstracts;
using Katalog.Entity;
using Katalog.ViewModels;

namespace Katalog.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IFileService _fileService;
        private readonly UserManager<Kullanici> _userManager;
        private Kullanici user;

        public AccountController(UserManager<Kullanici> userManager, IFileService fileService)
        {
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            user = await GetUser();
            ViewData["Title"] = user.UserName + " - Hesap Yönetimi";
            return View(user);
        }

       
        public async Task<IActionResult> EditProfile()
        {
            user = await GetUser();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(IFormFile file, Kullanici kullanici)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
          
            user.Email = kullanici.Email;
            user.PhoneNumber = kullanici.PhoneNumber;
            user.UserName = kullanici.UserName;

           
            await _fileService.Add(file,user);

            await _userManager.UpdateAsync(kullanici);

            return RedirectToAction("Index","Account");
        }

        //  [HttpPost]
        // public async Task<IActionResult> EditProfile(IFormFile file, Kullanici kullanici)
        // {
        //     var userx = await _userManager.GetUserAsync(HttpContext.User);
          
        //     userx.Email = user.Email;
        //     userx.PhoneNumber = user.PhoneNumber;
        //     userx.UserName = user.UserName;

        //     await _userManager.UpdateAsync(user);

        //     if(file != null)
        //     {
        //       await _fileService.Add(file,kullanici);
        //     }

            
        //     return RedirectToAction("Index","Account");
        // }







        // public async Task<IActionResult> UploadImage(IFormFile file)
        // {  
        //     user = await GetUser();
        //     await _fileService.Add(file, user);
        //     return RedirectToAction("Index");
        // }

        // [HttpGet]
        // public async Task<IActionResult> SifreDegistir()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public async Task<IActionResult> SifreDegistir(UserChangePasswordViewModel p)
        // {
        //     var user = await _userManager.GetUserAsync(HttpContext.User);
        //     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //     if (_userManager.CheckPasswordAsync(user, p.OldPassword).Result)
        //     {
        //         var result = await _userManager.ChangePasswordAsync(user, p.OldPassword, p.NewPassword);
        //         if (result.Succeeded)
        //         {
        //             return RedirectToAction("index", "hesap");
        //         }
        //         else
        //         {
        //             return View();
        //         }
        //     }
        //     else
        //     {
        //         return View();
        //     }
        // }


        // çağırmak için yazılan method
        [NonAction]
        private async Task<Kullanici> GetUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    
    }
}