using Xunit;
using CKK.Logic.Models;
using CKK.Logic;
using System;


namespace CKK.Tests2
{
    public class UnitTest1
    {
        [Fact]
        public void AddProductButter_ShoppingCartItem()
        {

            //ARRANGE
            int id3 = 8576;
            string name3 = "Butter";
            decimal price3 = 3.50m;

            int id2 = 2938;
            string name2 = "Milk";
            decimal price2 = 2.50m;

            var id = 6786;
            var name = "Cheese";
            var price = 4.73m;

            int idCustomer = 9879;
            string nameCustomer = "John";
            string addressCustomer = "4837 George Ave";

            //Butter Item
            Product product3 = new Product();
            product3.SetId(id3);
            product3.SetName(name3);
            product3.SetPrice(price3);
            //Milk Item
            Product product2 = new Product();
            product2.SetId(id2);
            product2.SetName(name2);
            product2.SetPrice(price2);
            //Cheese Item
            var product1 = new Product();
            product1.SetId(id);
            product1.SetName(name);
            product1.SetPrice(price);
            //Customer
            Customer john = new Customer();
            john.SetId(idCustomer);
            john.SetName(nameCustomer);
            john.SetAddress(addressCustomer);


            //ACT
            //ShoppingCartItem
            ShoppingCartItem cheeseItem = new ShoppingCartItem(product1, 10);
            cheeseItem.SetProduct(cheeseItem.GetProduct());

            ShoppingCartItem milkItem = new ShoppingCartItem(product2, 20);
            milkItem.SetProduct(milkItem.GetProduct());

            ShoppingCartItem butterItem = new ShoppingCartItem(product3, 30);
            butterItem.SetProduct(butterItem.GetProduct());

            //Shop Created and Named
            Store dairyShop = new Store();
            dairyShop.SetName("Dairy Shop");
            dairyShop.SetId(1234);

            //StoreItems created and added to store
            var cheese = new StoreItem(cheeseItem.GetProduct(), 10);
            dairyShop.AddStoreItem(cheese.GetProduct());

            StoreItem milk = new StoreItem(milkItem.GetProduct(), 20);
            dairyShop.AddStoreItem(milk.GetProduct());

            StoreItem butter = new StoreItem(butterItem.GetProduct(), 30);
            dairyShop.AddStoreItem(butter.GetProduct());

            //Customer Shopping
            ShoppingCart johnsCart = new ShoppingCart(john);
            johnsCart.AddProduct(butter.GetProduct());





            //Assert
            Assert.Equal(butter.GetProduct(), johnsCart.GetProduct(1).GetProduct());
        }
    }
}