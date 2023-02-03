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

        public ShopModel(IUnitOfWork unitOfWork)
        {
            unitOfWork = new UnitOfWork(conn);
            if(unitOfWork.Orders.GetById(1) != null && unitOfWork.Orders.GetById(1).ShoppingCartId == 1)
            {
               Order = unitOfWork.Orders.GetById(1);
            }
            else
            {
                Order = new Order() { OrderId = 1, OrderNumber = "1", ShoppingCartId = 1 };
            }
            UOW = unitOfWork;
            
            
        }
        
    }
}
