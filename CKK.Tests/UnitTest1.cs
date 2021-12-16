using System;
using Xunit;
using CKK.Logic.Models;
using CKK.Logic;


namespace CKK.Tests
{
    public class ShoppingCartItemTests
    {
        [Fact]
        public void AddProductCheese_ShoppingCartItem()
        {
            var id = 6786;
            var name = "Cheese";
            var price = 4.73m;
            //Arrange
            var product1 = new Product();
            product1.SetId(id);
            product1.SetName(name);
            product1.SetPrice(price);

            var cheese = new StoreItem(product1, 10);
            cheese.SetProduct(product1);


            //Act
           

            //Assert
            Assert.Equal(product1, Store.GetStoreItem(1);
        }
    }
}
