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

        public int ClearCart(int shoppingCartId)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_ClearCart @ShoppingCartId", new { ShoppingCartId = shoppingCartId });
                return item;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Query<ShoppingCartItem>("dbo.ShoppingCartItems_GetProducts @ShoppingCartId", new { ShoppingCartId = shoppingCartId }).ToList();
                return item;
            }
        }

        public decimal GetTotal(int shoppingCartId)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Query<decimal>("dbo.ShoppingCartItems_GetTotal @ShoppingCartId", new {ShoppingCartId = shoppingCartId}).ToList();
                return item.FirstOrDefault();
            }
        }

        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public int Update(ShoppingCartItem entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_Update @CustomerId, @ShoppingCartId, @ProductId, @Quantity", entity);
                return item;
            }
        }
    }
}
