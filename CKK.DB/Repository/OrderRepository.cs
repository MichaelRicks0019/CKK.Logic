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
        
        //Connection is created when Repository is created
        public OrderRepository(IConnectionFactory Conn)
            {
                conn = Conn;
            }

        //Methods use queries that refer to stored procedures that are located in the database
        //Refer to the interfaces for more info on what each method does
        public int Add(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var order = connection.Execute("dbo.Orders_Add @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity);
                return order;
            }
        }

        public async Task<int> AddAsync(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var order = await Task.Run(() => connection.Execute("dbo.Orders_Add @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity));
                return order;
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var order = connection.Execute("dbo.Orders_Delete @OrderId", new {OrderId = id});
                return order;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var orderTask = await Task.Run(() => connection.Execute("dbo.Orders_Delete @OrderId", new { OrderId = id }));
                return orderTask;
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

        public async Task<List<Order>> GetAllAsync()
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var orderTask = await Task.Run(() => connection.Query<Order>("dbo.Orders_GetAll").ToList());
                return orderTask;
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

        public async Task<Order> GetByIdAsync(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var orderTask = await Task.Run(() => connection.Query<Order>("dbo.Orders_GetById @OrderId", new { OrderId = id }).ToList());
                return orderTask.FirstOrDefault();
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

        public async Task<Order> GetOrderByCustomerIdAsync(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var orderTask = await Task.Run(() => connection.Query<Order>("dbo.Orders_GetOrderByCustomerId @CustomerId", new { CustomerId = id }).ToList());
                return orderTask.FirstOrDefault();
            }
        }

        public int Update(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var order = connection.Execute("dbo.Orders_Update @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity);
                return order;
            }
        }

        public async Task<int> UpdateAsync(Order entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var orderTask = await Task.Run( () => connection.Execute("dbo.Orders_Update @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", entity));
                return orderTask;
            }
        }
    }
}
