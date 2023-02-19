using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace CKK.Logic.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }
    }
}
