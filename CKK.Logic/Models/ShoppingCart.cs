using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CKK.Logic.Models
{
    public class ShoppingCart
    {

        private Customer customer;
        private ShoppingCartItem product1;
        private ShoppingCartItem product2;
        private ShoppingCartItem product3;

        public ShoppingCart(Customer cust)
        {
            customer = cust;
        }

        public int GetCustomerId()
        {
            return customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity >= 0)
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
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            if (product1 == null || product2 == null || product3 == null)
            {
                return AddProduct(prod, 1);
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if(product1 != null && product1.GetProduct().GetId() == prod.GetId())
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
            }
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (product1.GetProduct().GetId() == id)
            {
                return product1;
            }
            else if (product2.GetProduct().GetId() == id)
            {
                return product2;
            }
            else if (product3.GetProduct().GetId() == id)
            {
                return product3;
            }
            else
            {
                return null;
            }
        }

        public decimal GetTotal()
        {
            decimal total1 = product1.GetQuantity() * product1.GetProduct().GetPrice();
            decimal total2 = product2.GetQuantity() * product2.GetProduct().GetPrice();
            decimal total3 = product3.GetQuantity() * product3.GetProduct().GetPrice();
            decimal total = total1 + total2 + total3;
            return total;
        }

        public ShoppingCartItem GetProduct(int productNum)
        {
            switch (productNum)
            {
                case 1:
                    return product1;
                case 2:
                    return product2;
                case 3:
                    return product3;
                default:
                    return null;
            }

        }
    }
}
