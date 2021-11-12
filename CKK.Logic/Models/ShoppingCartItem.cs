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

        //No Idea if I did below right
        public void SetProduct(Product pr)
        {
            p = pr;
        }
      
        public Product GetProduct()
        {
            return p;
        }
        //No idea if above is correct
        public ShoppingCartItem(Product product, int quantity)
        {
            Quantity = quantity;
            product = p;
        }
    }
}
