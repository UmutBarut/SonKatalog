using Microsoft.AspNetCore.Mvc;
using Katalog.Entity;
using Katalog.Dataaccess.Concrete.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Katalog.ViewModels;


namespace Katalog.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        
        public SepetController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}