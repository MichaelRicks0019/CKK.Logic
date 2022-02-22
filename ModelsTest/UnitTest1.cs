using System;
using Xunit;
using CKK.Logic.Models;

namespace ModelsTest
{
    public class UnitTest1
    {
        [Fact]
        public void IfAddProductsTest()
        {
            Product teriyakiJerky = new Product();
            teriyakiJerky.SetId(0001);
            teriyakiJerky.SetName("Teriyaki Beef Jerky");
            teriyakiJerky.SetPrice(4.99m);

            Customer jerry = new Customer();
            jerry.SetId(1234);
            jerry.SetName("Jerry");
            jerry.SetAddress("5642 White Boy St, UT 84404");

            Store theJerkyStore = new Store();
            theJerkyStore.SetId(4422);
            theJerkyStore.SetName("The Jerky Store \"Where we Jerk your Meat!\" ");
            theJerkyStore.AddStoreItem(teriyakiJerky, 20);

            ShoppingCart jerrysShoppingCart = new ShoppingCart(jerry);
            jerrysShoppingCart.AddProduct(theJerkyStore.FindStoreItemById(0001).GetProduct(), 3);

            Assert.Equal(teriyakiJerky.GetId(), jerrysShoppingCart.GetProductById(0001).GetProduct().GetId());
        }
    }
}

