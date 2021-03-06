using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private Customer customer;
        private List<ShoppingCartItem> products;

        public ShoppingCart(Customer cust)
        {
            products = new List<ShoppingCartItem>();
            customer = cust;
        }
        //Products Property
        public List<ShoppingCartItem> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }
        //Customer Property
        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }

        public int GetCustomerId()
        {
            return customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException($"Quantity must be more than 0");
            }

            var productToBeAdded = GetProductById(prod.GetId());

            if(productToBeAdded != null)
            { 
                productToBeAdded.SetQuantity(productToBeAdded.GetQuantity() + quantity);
                return productToBeAdded;
            }
            else
            {
                ShoppingCartItem item = new ShoppingCartItem(prod, quantity);
                products.Add(item);
                return item;
            }
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, $"Quantity must be more than 0");
            }

            var existingProduct = GetProductById(id);

            if (existingProduct != null)
            {
                if (existingProduct.GetQuantity() - quantity <= 0)
                {
                    existingProduct.SetQuantity(0);
                    products.Remove(existingProduct);
                }
                else if (existingProduct.GetQuantity() - quantity > 0)
                {
                    existingProduct.SetQuantity(existingProduct.GetQuantity() - quantity);
                }
                return existingProduct;
            }
            else
            {
                throw new ProductDoesNotExistException($"Product does not exist");
            }
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException($"Id must be greater than or equal to 0");
            }

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