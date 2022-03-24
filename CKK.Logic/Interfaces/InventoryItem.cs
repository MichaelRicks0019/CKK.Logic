using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

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
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException($"Quantity must be more than 0");
                }
                else
                {
                    quantity = value;
                }
            }
        }


        
    }
}
