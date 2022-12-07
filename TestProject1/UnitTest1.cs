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
            Order of = new Order() { CustomerId = 2, OrderNumber = "1234", ShoppingCartId = 2, OrderId = 2 };
            Order og = new Order() { CustomerId = 3, OrderNumber = "frds", ShoppingCartId = 3, OrderId = 3 };
            Order oh = new Order() { CustomerId = 4, OrderNumber = "4321", ShoppingCartId = 4, OrderId = 4 };





            /*uow.Orders.Add(of);
            uow.Orders.Add(og);
            uow.Orders.Add(oh);
            uow.Orders.Add(od);*/
            // uow.Orders.Delete(1);
            List<Order> orders = new List<Order>();

               orders =  uow.Orders.GetAll();

            Assert.Equal(orders, uow.Orders.GetAll());
            }
        }
    }