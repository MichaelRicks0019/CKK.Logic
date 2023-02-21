using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IUnitOfWork
    {
        //These are what are called when a new Unit of Work is created.
        IProductRepository<Product> Products { get; }

        IOrderRepository<Order> Orders { get; }

        IShoppingCartRepository ShoppingCarts { get; }
    }
}
