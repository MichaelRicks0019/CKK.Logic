using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {

        private Customer customer;
        private List<ShoppingCartItem> products;

        public ShoppingCart(Customer cust)
        {
            products = new List<ShoppingCartItem>();
            customer = cust;
        }

        public int GetCustomerId()
        {
            return customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            bool itemFound = false;
            foreach (ShoppingCartItem item in products)
            {
                if (quantity <= 0)
                {
                    return null;
                }
                else if (item.GetProduct() == prod && quantity > 0)
                {
                    itemFound = true;
                    item.SetQuantity(item.GetQuantity() + quantity);
                    return item;
                }
            }
            if (itemFound == false)
            {
                    ShoppingCartItem item = new ShoppingCartItem(prod, quantity);
                    products.Add(new ShoppingCartItem(prod, quantity));
                    return item;
            }
            else
            {
                return null;
            }
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            foreach (ShoppingCartItem item in products)
            {
                if (item.GetProduct().GetId() == id && item.GetQuantity() - quantity <= 0)
                {
                    item.SetQuantity(0);
                    products.Remove(item);
                    return item;
                }
                else if (item.GetProduct().GetId() == id && item.GetQuantity() - quantity > 0)
                {
                    item.SetQuantity(item.GetQuantity() - quantity);
                    return item;
                }
            }
            return null;
        }

        public ShoppingCartItem GetProductById(int id)
        {
           foreach (ShoppingCartItem item in products)
            {
                if (item.GetProduct().GetId() == id)
                {
                    return item;
                }
            }
            return null;
        }

        public decimal GetTotal()
        {
            decimal total = 0m;
            foreach (ShoppingCartItem item in products)
            {
                total += item.GetTotal();
            }
            return total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return products;
        }
    }
}












/* Add Product OLD

 * if (quantity >= 0)
            {
                //Product 1
                if (product1 != null && product1.GetProduct().GetId() == prod.GetId())
                {
                    product1.SetQuantity(product1.GetQuantity() + quantity);
                    return product1;
                }
                else if (product1 == null)
                {
                    //ADD NEW PRODUCT OR FIGURE OUT HOW TO MAKE PRODUCT1 ACCEPT ITEM
                    product1 = new ShoppingCartItem(prod, quantity);
                    product1.SetQuantity(quantity);
                    product1.SetProduct(prod);
                    return product1;
                }
                //Product 2
                else if (product2 != null && product2.GetProduct().GetId() == prod.GetId())
                {
                    product2.SetQuantity(product2.GetQuantity() + quantity);
                    return product2;
                }
                else if (product2 == null)
                {
                    product2 = new ShoppingCartItem(prod, quantity);
                    product2.SetQuantity(quantity);
                    product2.SetProduct(prod);
                    return product2;
                }
                //Product 3
                else if (product3 != null && product3.GetProduct().GetId() == prod.GetId())
                {
                    product3.SetQuantity(product3.GetQuantity() + quantity);
                    return product3;
                }
                else if (product3 == null)
                {
                    product3 = new ShoppingCartItem(prod, quantity);
                    product3.SetQuantity(quantity);
                    product3.SetProduct(prod);
                    return product3;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

 
 
 
 
    Remove Product OLD
 * if(product1 != null && product1.GetProduct().GetId() == prod.GetId())
            {
                int qty = product1.GetQuantity();
                if (quantity < qty)
                {
                    product1.SetQuantity(qty - quantity);
                    return product1;
                }
                else
                {
                    product1 = null;
                    return product1;
                }
            }
            else if (product2 != null && product2.GetProduct().GetId() == prod.GetId())
            {
                int qty = product2.GetQuantity();
                if (quantity < qty)
                {
                    product2.SetQuantity(qty - quantity); 
                    return product2;
                }
                else
                {
                    product2 = null;
                    return product2;
                }
            }
            else if (product3 != null && product3.GetProduct().GetId() == prod.GetId())
            {
                int qty1 = product3.GetQuantity();
                if (quantity < qty1)
                {
                    product3.SetQuantity(qty1 - quantity);
                    return product3;
                }
                else
                {
                    product3 = null;
                    return product3; 
                }
            }
            else
            {
                return null;
            }*/