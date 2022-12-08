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

            Product p1 = new Product() { Id = 1, Name = "Cheese", Price = 7.99m, Quantity = 12 };

            uow.Products.Add(p1);




           
           

            }
        }
    }