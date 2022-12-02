using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.DB.UOW;

namespace CKK.DB.Repository
{
    class OrderRepository<Order> : IOrderRepository<Order>
    {
        public IConnectionFactory conn;
        public OrderRepository(IConnectionFactory Conn)
        {
            conn = Conn;
        }
        public int Add(Order entity)
        {
            using (conn.GetConnection)
            {

            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
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
