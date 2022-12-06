using System;
using Xunit;
using CKK.Logic.Models;
using CKK.DB.UOW;
using CKK.DB.Interfaces;

namespace ModelsTest
{
    public class UnitTest1
    {
        [Fact]
        public void IfAddProductsTest()
        {
            IConnectionFactory conn = new DatabaseConnectionFactory();
            UnitOfWork uow = new UnitOfWork(conn);

            Order od = new Order() { CustomerId = 1, OrderNumber = "af3ed", ShoppingCartId = 1, OrderId = 1 };

            uow.Orders.Add(od);
        }
    }
}

