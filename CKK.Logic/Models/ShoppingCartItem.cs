using System;
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

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public ShoppingCartItem(Product product, int quantity)
        {
            Quantity = quantity;
            product = p;
        }
    }
}
