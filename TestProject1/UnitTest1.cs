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

            Product p1 = new Product() { Id = 1, Name = "Cheese", Price = .10m, Quantity = 12 };
            Product p2 = new Product() { Id = 2, Name = "Butter", Price = .50m, Quantity = 12 };
            Product p3 = new Product() { Id = 4, Name = "Hamburger", Price = 2m, Quantity = 4 };
            List<Product> products = new List<Product>();

            uow.Products.Add(p3);

            products = uow.Products.GetAll();

            uow.Products.GetByName("Butterfdsfdf");
            uow.Products.Update(p1);







        }
        }
    }