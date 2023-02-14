using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic.Models;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IConnectionFactory conn = new DatabaseConnectionFactory();
            UnitOfWork UOW = new UnitOfWork(conn);

            Product item = new Product() { Id = 9, Name = "Sugar", Price = 4.99m, Quantity = 10 };

            UOW.Products.AddAsync(item);

        }
    }
}
