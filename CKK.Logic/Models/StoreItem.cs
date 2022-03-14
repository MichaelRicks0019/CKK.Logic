﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
     public class StoreItem : InventoryItem
    {
        //Get and Set for Quantity
        public int GetQuantity()
        {
            return base.Quantity;
        }
        public void SetQuantity(int storeItemQuantity)
        {
            base.Quantity = storeItemQuantity;
        }
        //Get and Set for product
        public void SetProduct(Product storeItemProduct)
        {
            base.Product = storeItemProduct;
        }
        public Product GetProduct()
        {
            return base.Product;
        }
        //Constructor
        public StoreItem (Product storeItemProduct, int storeItemQuantity)
        {
            base.Quantity = storeItemQuantity;
            base.Product = storeItemProduct;
        }
    }
}
