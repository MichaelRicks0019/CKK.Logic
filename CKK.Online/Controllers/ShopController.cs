using Microsoft.AspNetCore.Mvc;
using CKK.Logic;
using CKK.DB;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Online.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.TeamFoundation.Build.WebApi;
using CKK.Logic.Models;
using System.Threading.Tasks;

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
            string statusMessage = "Order Placed Successfully";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
            return View("Checkout", model);
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute] int productId, [FromQuery] int quantity)
        {
            var order = UOW.Orders.GetByIdAsync(1).Result;
            ShoppingCartItem item = new ShoppingCartItem() { CustomerId = order.CustomerId, ShoppingCartId = order.ShoppingCartId, ProductId = productId, Quantity = quantity };
            var items = UOW.ShoppingCarts.GetProducts(order.ShoppingCartId);
            //Checks if products is already in ShoppingCart. If so, update feature is used.
            bool productExists = false;
            bool productMaxQuantity = false;

            foreach(ShoppingCartItem i in items)
            {
                if(i.ProductId == productId)
                {
                    productExists = true;
                    if(productExists == true && item.Quantity > i.Quantity)
                    {
                        productMaxQuantity = true;
                        break;
                    }
                }
            }
            if(productExists == true)
            {
                UOW.ShoppingCarts.Update(item);
            }
            else if (productMaxQuantity == true)
            {

            }
            else
            {
                UOW.ShoppingCarts.Add(item);
            }

            var total = UOW.ShoppingCarts.GetTotal(order.ShoppingCartId).ToString("c");
            return Ok(total);
        }
    }
}
