using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    interface IUnitOfWork<T>
    {
        IProductRepository<T> Products { get; }

        IOrderRepository<T> Orders { get; }

        IShoppingCartRepository ShoppingCarts { get; }
    }
}
