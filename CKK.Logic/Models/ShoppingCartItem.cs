﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class ShoppingCartItem
    {
        //Product : Product
        Product p = new Product();
        private int quantity;

        //Get and Set for Quantity
        public int GetQuantity()
        {
            return quantity;
        }
        public void SetQuantity(int shoppingCartItemQuantity)
        {
            quantity = shoppingCartItemQuantity;
        }
        //Get and Set for product
        public void SetProduct(Product shoppingCartItemProduct)
        {
            p = shoppingCartItemProduct;
        }
        public Product GetProduct()
        {
            return p;
        }
        //Constructor
        public ShoppingCartItem(Product shoppingCartItemProduct, int ShoppingCartItemQuantity)
        {
            quantity = ShoppingCartItemQuantity;
            p = shoppingCartItemProduct;
        }
    }
}
