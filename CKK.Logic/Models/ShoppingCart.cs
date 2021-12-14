using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;


namespace CKK.Logic
{
    class ShoppingCart
    {
        private Customer newCustomer = new Customer();
        private ShoppingCartItem product1;
        private ShoppingCartItem product2;
        private ShoppingCartItem product3;

        public ShoppingCart(Customer cust)
        {
            newCustomer = cust;
        }

        public void GetCustomerId()
        {
            newCustomer.GetId();
        }

        public void AddProduct(Product prod, int quantity)
        {
            if (product1 == null)
            {
                product1.SetProduct(prod);
                product1.SetQuantity(quantity);
            }
            else if (product2 == null)
            {
                product2.SetProduct(prod);
                product2.SetQuantity(quantity);
            }
            else if (product3 == null)
            {
                product3.SetProduct(prod);
                product2.SetProduct(quantity);
            }
            else
            {

            }
        }

        public void AddProduct(Product prod)
        {
            if (product1 == null)
            {
                product1.SetProduct(prod);
            }
            else if (product2 == null)
            {
                product2.SetProduct(prod);
            }
            else if (product3 == null)
            {
                product3.SetProduct(prod);
            }
            else
            {

            }
        }

        public void RemoveProduct(Product prod, int quantity)
        {
            
        }

        public ShoppingCartItem GetProductById(int id)
        {
            
        }

        public decimal GetTotal()
        {

        }

        public ShoppingCartItem GetProduct(int productNum)
        {

        }
    }
}
