using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IOrderRepository<Order> : IGenericRepository<Order>
    {
        //Regular Methods

        //Returns Order based on CustomerId
        Order GetOrderByCustomerId(int id);

        //Async Methods

        //Same as above but asynchronous
        Task<Order> GetOrderByCustomerIdAsync(int id);
    }
}
