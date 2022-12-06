using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IOrderRepository<Order> : IGenericRepository<Order> where Order : CKK.Logic.Models.Order
    {
        Order GetOrderByCustomerId(int id);
    }
}
