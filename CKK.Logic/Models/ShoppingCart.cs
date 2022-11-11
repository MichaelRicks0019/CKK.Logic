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
        //Properties
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
       
        //Constructor
        public ShoppingCart(Customer cust)
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            Customer = cust;
        }
        
        //Methods
        public int GetCustomerId()
        {
            return Customer.GetId();
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
                ShoppingCartItems.Add(item);
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
                    ShoppingCartItems.Remove(existingProduct);
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

            foreach (ShoppingCartItem item in ShoppingCartItems)
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
            foreach (ShoppingCartItem item in ShoppingCartItems)
            {
                total += item.GetTotal();
            }
            return total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return ShoppingCartItems;
        }
    }
}