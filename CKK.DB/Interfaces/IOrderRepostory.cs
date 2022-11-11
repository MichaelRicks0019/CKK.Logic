﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    interface IOrderRepository<Order> : IGenericRepository<Order>
    {
        Order GetOrderByCustomerId(int id);
    }
}
