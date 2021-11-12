using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class StoreItem
    {
        Product p = new Product();
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        //No idea is below is correct
        public void SetProduct(Product pr)
        {
            p = pr;
        }

        public Product GetProduct()
        {
            return p;
        }
        //No idea if above is correct
        public StoreItem(Product product, int quantity)
        {
            Quantity = quantity;
            product = p;
        }
    }
}
