using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;


namespace CKK.Logic
{
    public class ShoppingCart
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

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (product1 == null)
            {
                prod = product1.GetProduct();
                if (quantity >= 0)
                {
                    product1.SetQuantity(quantity);
                }
                return product1;
            }
            else if (product2 == null)
            {
                prod = product2.GetProduct();
                if (quantity >= 0)
                {
                    product2.SetQuantity(quantity);
                }
                return product2;
            }
            else if (product3 == null)
            {
                prod = product3.GetProduct();
                if (quantity >= 0)
                {
                    product2.SetQuantity(quantity);
                }
                return product3;
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            if (product1 == null)
            {
                prod = product1.GetProduct();
                product1.SetQuantity(1);
                return product1;
            }
            else if (product2 == null)
            {
                prod = product2.GetProduct();
                product2.SetQuantity(1);
                return product2;

            }
            else if (product3 == null)
            {
                prod = product3.GetProduct();
                product3.SetQuantity(1);
                return product3;
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
