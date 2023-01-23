using Microsoft.AspNetCore.Mvc;

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
