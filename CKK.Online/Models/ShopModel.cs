using CKK.DB.Interfaces;
using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        public Order Order { get; set; }
        public IUnitOfWork UOW { get; set; }

        public ShopModel(IUnitOfWork unitOfWork)
        {
            Order.OrderNumber = "1";
            Order.ShoppingCartId = 100;
        }
        
    }
}
