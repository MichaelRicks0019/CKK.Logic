using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        public Order Order { get; set; }
        public IUnitOfWork UOW { get; set; }
        private IConnectionFactory conn = new DatabaseConnectionFactory();

        //Order is deleted and recreated for user. This is for testing
        public ShopModel(IUnitOfWork unitOfWork)
        {
            unitOfWork = new UnitOfWork(conn);
            unitOfWork.Orders.Delete(1);
            Order = new Order() { CustomerId = 1, OrderId = 1, OrderNumber = "1", ShoppingCartId = 1 };
            unitOfWork.Orders.Add(Order);
            UOW = unitOfWork;
            
            
        }
        
    }
}
