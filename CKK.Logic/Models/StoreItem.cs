using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class StoreItem
    {
        //Product : Product
        private Product p;
        private int quantity;

        //Get and Set for Quantity
        public int GetQuantity()
        {
            return quantity;
        }
        public void SetQuantity(int storeItemQuantity)
        {
            quantity = storeItemQuantity;
        }
        //Get and Set for product
        public void SetProduct(Product storeItemProduct)
        {
            p = storeItemProduct;
        }
        public Product GetProduct()
        {
            return p;
        }
        //Constructor
        public StoreItem (Product storeItemProduct, int storeItemQuantity)
        {
            quantity = storeItemQuantity;
            p = storeItemProduct;
        }
    }
}
