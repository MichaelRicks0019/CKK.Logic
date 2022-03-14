using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        //Inventory is base class for ShoppingCartItem and StoreItem
        public Product Product { get; set; }
        private int quantity;

        public  int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (quantity < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(quantity), quantity,
                        $"Quantity must be more than 0");
                }
                quantity = value;
            }
        }


        
    }
}
