using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.Components
{
    [ViewComponent]
    public class Toolbar : ViewComponent
    {
        private readonly UserManager<Kullanici> _userManager;

        public Toolbar(UserManager<Kullanici> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View("_Toolbar",user);
        }
    }
}