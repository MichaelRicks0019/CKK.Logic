using Microsoft.AspNetCore.Mvc;
using CKK.Logic;
using CKK.DB;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Online.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.TeamFoundation.Lab.Client;

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
            var model = new ShopModel(UOW);
            UOW.ShoppingCarts.ClearCart(model.Order.ShoppingCartId); //Clear the cart on refresh
            return View("ShoppingCart", model);
        }

        public IActionResult CheckOutCustomer([FromQuery]int orderId)
        {
            string statusMessage = "";
            //Get order info

            //Update quantities of products in inventory

            //For the assignment we just delete or clear 

            statusMessage = "Order Placed Successfully";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
            return View("Checkout", model);
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute]int productId, [FromQuery]int quantity) 
        {
            return View();
        }
    }
}
