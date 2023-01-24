using Microsoft.AspNetCore.Mvc;
using CKK.Logic;
using CKK.DB;
using CKK.DB.Interfaces;
using CKK.DB.UOW;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork UOW;
        public ShopController(IUnitOfWork connection) 
        {
            UOW = connection;
        }

        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckOutCustomer([FromQuery]int orderId)
        {
            return View();
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute]int productId, [FromQuery]int quantity) 
        {
            return View();
        }
    }
}
