using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;

namespace CKK.DB.Repository
{
    class ShoppingCartRepository : IShoppingCartRepository
    {
        public IConnectionFactory conn;
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            conn = Conn;
        }
        public int Add(ShoppingCartItem entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_Add @CustomerId, @ShoppingCartId, @ProductId, @Quantity", entity);
                return entity.ShoppingCartId;
            }

        }

        public ShoppingCartItem AddToCart(string itemName, int quantity)
        {
            throw new NotImplementedException();
        }

        public int ClearCart(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotal(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public int Update(ShoppingCartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
