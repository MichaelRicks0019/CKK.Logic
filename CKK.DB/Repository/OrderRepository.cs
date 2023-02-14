using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Dapper;

namespace CKK.DB.Repository
{
    public class OrderRepository<Order> : IOrderRepository<Order> where Order : CKK.Logic.Models.Order
    {
        public IConnectionFactory conn;
        
        public OrderRepository(IConnectionFactory Conn)
            {
                conn = Conn;
            }

        public int Add(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                connection.Execute("dbo.Orders_Add @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity);
                return entity.OrderId;
            }
        }

        public Task<int> AddAsync(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                await Task.Run(() => connection.Execute("dbo.Orders_Add @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity));
                return entity.OrderId;
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                connection.Execute("dbo.Orders_Delete @OrderId", new {OrderId = id}));
                return id;
            }
        }

        public Task<tint> DeleteAsync(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                await Task.Run(() => connection.Execute("dbo.Orders_Delete @OrderId", new { OrderId = id }));
                return id;
            }
        }

        public List<Order> GetAll()
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var order = connection.Query<Order>("dbo.Orders_GetAll").ToList();
                return order;
            }
        }

        public Order GetById(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            { 
                var order = connection.Query<Order>("dbo.Orders_GetById @OrderId", new {OrderId = id}).ToList();
                return order.FirstOrDefault();
            }
        }

        public Order GetOrderByCustomerId(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var order = connection.Query<Order>("dbo.Orders_GetOrderByCustomerId @CustomerId", new { CustomerId = id }).ToList();
                return order.FirstOrDefault();
            }
        }

        public int Update(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                connection.Execute("dbo.Orders_Update @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity);
                return entity.OrderId;
            }
        }
    }
}
