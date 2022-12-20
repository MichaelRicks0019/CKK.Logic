using Xunit;
using CKK.Logic.Models;
using CKK.DB.UOW;
using CKK.DB.Interfaces;
using System.Security.Permissions;

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
            Product p3 = new Product() { Id = 4, Name = "Hamburger", Price = 3m, Quantity = 10 };
            List<Product> products = new List<Product>();
            List<ShoppingCartItem> items = new List<ShoppingCartItem>();

            ShoppingCartItem s1 = new ShoppingCartItem() { CustomerId = 1, ShoppingCartId = 1, ProductId = 2, Quantity = 5 };
            decimal priceTotal = uow.ShoppingCarts.GetTotal(1);
            uow.ShoppingCarts.Update(s1);
            Console.ReadKey();
            uow.ShoppingCarts.ClearCart(1);

            products = uow.Products.GetAll();

            uow.Products.GetByName("Butterfdsfdf");
          







        }
        }
    }