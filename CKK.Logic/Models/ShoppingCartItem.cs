using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
     public class ShoppingCartItem : InventoryItem
    {
        //Get and Set for Quantity
        public int GetQuantity()
        {
            return base.Quantity;
        }
        public void SetQuantity(int shoppingCartItemQuantity)
        {
            base.Quantity = shoppingCartItemQuantity;
        }
        //Get and Set for product
        public void SetProduct(Product shoppingCartItemProduct)
        {
            base.Product = shoppingCartItemProduct;
        }
        public Product GetProduct()
        {
            return base.Product;
        }

        public decimal GetTotal()
        {
            return base.Product.Price * GetQuantity();
        }
        //Constructor
        public ShoppingCartItem(Product shoppingCartItemProduct, int ShoppingCartItemQuantity)
        {
            base.Quantity = ShoppingCartItemQuantity;
            base.Product = shoppingCartItemProduct;
        }
    }
}
