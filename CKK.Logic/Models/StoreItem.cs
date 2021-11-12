using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    class StoreItem
    {
        Product p = new Product();
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public StoreItem(Product product, int quantity)
        {
            Quantity = quantity;
            product = p;
        }
    }
}
