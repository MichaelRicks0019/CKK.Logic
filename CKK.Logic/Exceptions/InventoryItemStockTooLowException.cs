using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException() : base("Inventory Item Stock is too low")
        {

        }

        public InventoryItemStockTooLowException(string messageValue) : base(messageValue)
        {

        }

        public InventoryItemStockTooLowException(string messageValue, Exception inner) : base(messageValue, inner)
        {

        }
    }
}
