using Microsoft.AspNetCore.Mvc;
using CKK.Logic;
using CKK.DB;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Online.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.TeamFoundation.Build.WebApi;
using CKK.Logic.Models;

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

        /*[HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            
        }*/

        public IActionResult CheckOutCustomer([FromQuery]int orderId)
        {
            //Get order info
            //Update quantities of products in inventory
            //For the assignment we just delete or clear 

            string statusMessage = "Order Placed Successfully";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
            return View("Checkout", model);
        }

        [HttpGet]
        public IActionResult Add(Product prod) 
        {
            var order = UOW.Orders.GetById(1);
            ShoppingCartItem item = new ShoppingCartItem() { CustomerId = order.CustomerId, ShoppingCartId = order.ShoppingCartId, ProductId = prod.Id, Quantity = prod.Quantity };

            var test = UOW.ShoppingCarts.Add(item);

            var total = UOW.ShoppingCarts.GetTotal(order.ShoppingCartId).ToString("c");
            return Ok(total);
        }
    }
}
