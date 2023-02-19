using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    [Serializable]
     public class ShoppingCartItem : InventoryItem
    {
        public int CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
