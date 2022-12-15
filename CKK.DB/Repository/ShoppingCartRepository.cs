using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.Logic.Exceptions;
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

        public ShoppingCartItem AddToCart(string itemName, int quantity, int shoppingCartId)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                connection.Execute("dbo.ShoppingCartItems_AddToCart @Name, @CustomerId, @ShoppingCartId, @Quantity", new {Name = itemName, CustomerId = 1, ShoppingCartId = shoppingCartId, Quantity = quantity});
                var item = connection.Query<ShoppingCartItem>($"SELECT * FROM dbo.ShoppingCartItems WHERE ShoppingCartId = {shoppingCartId} AND ProductId = (SELECT Id FROM dbo.Products WHERE Name = '{itemName}';");
                return item.FirstOrDefault();
            }
        }

        public int ClearCart(int shoppingCartId)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_ClearCart, @ShoppingCartId", shoppingCartId);
                return item;
            }
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
