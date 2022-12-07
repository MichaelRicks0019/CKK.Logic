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
    class OrderRepository<Order> : IOrderRepository<Order> where Order : CKK.Logic.Models.Order
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
                List<Order> order = new List<Order> { entity };
                connection.Execute("dbo.Orders_Add @OrderId, @OrderNumber, @CustomerId, @ShoppingCartId", order);
                return entity.OrderId;
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                CKK.Logic.Models.Order order = new Logic.Models.Order() { OrderId = id };
                connection.Execute("dbo.Orders_Delete @OrderId", order);
                return id;
            }
        }

        public List<Order> GetAll()
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                List<Order> order = new List<Order>();
                order = connection.Query<Order>("dbo.Orders_GetAll").ToList();
                return order;
            }
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
