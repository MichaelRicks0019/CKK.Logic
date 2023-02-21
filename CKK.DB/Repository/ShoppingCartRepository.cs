using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Dapper;
using static Dapper.SqlMapper;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public IConnectionFactory conn;

        //Connection is created when Repository is created
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            conn = Conn;
        }

        //Methods use queries that refer to stored procedures that are located in the database
        //Refer to the interfaces for more info on what each method does
        public int Add(ShoppingCartItem entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_Add @CustomerId, @ShoppingCartId, @ProductId, @Quantity", entity);
                return item;
            }
        }
        
        public async Task<int> AddAsync(ShoppingCartItem entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var itemTask = await Task.Run(() => connection.Execute("dbo.ShoppingCartItems_Add @CustomerId, @ShoppingCartId, @ProductId, @Quantity", entity));
                return itemTask;
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
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_Ordered @ShoppingCartId,", new { ShoppingCartId = shoppingCartId } );
            }
        }

        public int Update(ShoppingCartItem entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = connection.Execute("dbo.ShoppingCartItems_Update @CustomerId, @ShoppingCartId, @ProductId, @Quantity", entity);
                return item;
            }
        }

        public async Task<int> UpdateAsync(ShoppingCartItem entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var item = await Task.Run( () => connection.Execute("dbo.ShoppingCartItems_Update @CustomerId, @ShoppingCartId, @ProductId, @Quantity", entity));
                return item;
            }
        }
    }
}
