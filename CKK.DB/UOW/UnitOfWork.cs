using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CKK.DB.Interfaces;
using CKK.DB.Repository;
using CKK.Logic.Models;

namespace CKK.DB.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository<Product> Products { get; }

        public IOrderRepository<Order> Orders { get; }

        public IShoppingCartRepository ShoppingCarts { get; }

        public UnitOfWork(IConnectionFactory Conn)
        {
            Products = new ProductRepository<Product>(Conn);
            Orders = new OrderRepository<Order>(Conn);
            ShoppingCarts = new ShoppingCartRepository(Conn);
        }
    }
}
