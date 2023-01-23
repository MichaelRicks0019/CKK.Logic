using Microsoft.AspNetCore.Mvc;
using CKK.Logic.

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        public ShopController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
