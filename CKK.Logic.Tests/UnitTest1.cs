using Microsoft.VisualStudio.TestTools.UnitTesting;
using CKK.Logic;
using CKK.Logic.Models;

namespace CKK.Logic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddProductButter_ShoppingCart()
        {

            int qty = 5;
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
            Product product1 = new Product();
            product1.SetId(id);
            product1.SetName(name);
            product1.SetPrice(price);
            //Customer
            Customer john = new Customer();
            john.SetId(idCustomer);
            john.SetName(nameCustomer);
            john.SetAddress(addressCustomer);


            //ACT
            //Shop Created and Named
            Store dairyShop = new Store();
            dairyShop.SetName("Dairy Shop");
            dairyShop.SetId(1234);

            //StoreItems created and added to store
            StoreItem cheese = new StoreItem(product1, 10);
            dairyShop.AddStoreItem(cheese.GetProduct());

            StoreItem milk = new StoreItem(product2, 20);
            dairyShop.AddStoreItem(milk.GetProduct());

            StoreItem butter = new StoreItem(product3, 30);
            dairyShop.AddStoreItem(butter.GetProduct());

            /*
            //Shopping Cart Items
            ShoppingCartItem cheeseItem = new ShoppingCartItem(cheese.GetProduct(), cheese.GetQuantity());
            ShoppingCartItem milkItem = new ShoppingCartItem(milk.GetProduct(), milk.GetQuantity());
            ShoppingCartItem butterItem = new ShoppingCartItem(cheese.GetProduct(), milk.GetQuantity());
            */



            //Customer Shopping
            ShoppingCart johnsCart = new ShoppingCart(john);
            johnsCart.AddProduct(butter.GetProduct(), 1);
            johnsCart.AddProduct(milk.GetProduct(), 5);
            johnsCart.AddProduct(cheese.GetProduct());
            johnsCart.AddProduct(butter.GetProduct(), 4);


            //Assert
            Assert.AreEqual(butter.GetProduct(), johnsCart.GetProduct(1).GetProduct());

            Assert.AreEqual(milk.GetProduct(), johnsCart.GetProduct(2).GetProduct());

            Assert.AreEqual(cheese.GetProduct(), johnsCart.GetProduct(3).GetProduct());

            Assert.AreEqual(qty, johnsCart.GetProductById(id3).GetQuantity());
        }


        [TestMethod]
        public void RemoveProductButter_ShoppingCart()
        {
            int isTwo = 2;
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
            Product product1 = new Product();
            product1.SetId(id);
            product1.SetName(name);
            product1.SetPrice(price);
            //Customer
            Customer john = new Customer();
            john.SetId(idCustomer);
            john.SetName(nameCustomer);
            john.SetAddress(addressCustomer);


            //ACT
            //Shop Created and Named
            Store dairyShop = new Store();
            dairyShop.SetName("Dairy Shop");
            dairyShop.SetId(1234);

            //StoreItems created and added to store
            StoreItem cheese = new StoreItem(product1, 10);
            dairyShop.AddStoreItem(cheese.GetProduct());

            StoreItem milk = new StoreItem(product2, 20);
            dairyShop.AddStoreItem(milk.GetProduct());

            StoreItem butter = new StoreItem(product3, 30);
            dairyShop.AddStoreItem(butter.GetProduct());

            /*
            //Shopping Cart Items
            ShoppingCartItem cheeseItem = new ShoppingCartItem(cheese.GetProduct(), cheese.GetQuantity());
            ShoppingCartItem milkItem = new ShoppingCartItem(milk.GetProduct(), milk.GetQuantity());
            ShoppingCartItem butterItem = new ShoppingCartItem(cheese.GetProduct(), milk.GetQuantity());
            */



            //Customer Shopping
            ShoppingCart johnsCart = new ShoppingCart(john);
            johnsCart.AddProduct(butter.GetProduct(), 1);
            johnsCart.AddProduct(milk.GetProduct(), 5);
            johnsCart.AddProduct(cheese.GetProduct());
            johnsCart.AddProduct(butter.GetProduct(), 4);

            johnsCart.RemoveProduct(butter.GetProduct(), butter.GetQuantity());
            johnsCart.RemoveProduct(milk.GetProduct(), 3);
            johnsCart.RemoveProduct(cheese.GetProduct(), 20);

            Assert.IsNull(johnsCart.GetProduct(1));
            Assert.IsNull(johnsCart.GetProduct(3));
            Assert.AreEqual(isTwo, johnsCart.GetProduct(2).GetQuantity());
        }


        [TestMethod]
        public void GetTotal_ShoppingCart()
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
            Product product1 = new Product();
            product1.SetId(id);
            product1.SetName(name);
            product1.SetPrice(price);
            //Customer
            Customer john = new Customer();
            john.SetId(idCustomer);
            john.SetName(nameCustomer);
            john.SetAddress(addressCustomer);


            //ACT
            //Shop Created and Named
            Store dairyShop = new Store();
            dairyShop.SetName("Dairy Shop");
            dairyShop.SetId(1234);

            //StoreItems created and added to store
            StoreItem cheese = new StoreItem(product1, 10);
            dairyShop.AddStoreItem(cheese.GetProduct());

            StoreItem milk = new StoreItem(product2, 20);
            dairyShop.AddStoreItem(milk.GetProduct());

            StoreItem butter = new StoreItem(product3, 30);
            dairyShop.AddStoreItem(butter.GetProduct());


            //Customer Shopping
            ShoppingCart johnsCart = new ShoppingCart(john);
            johnsCart.AddProduct(butter.GetProduct(), 1);
            johnsCart.AddProduct(milk.GetProduct(), 5);
            johnsCart.AddProduct(cheese.GetProduct());
            johnsCart.AddProduct(butter.GetProduct(), 4);

            johnsCart.GetTotal();

            
        }
    }
}
