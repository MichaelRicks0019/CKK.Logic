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
    [Serializable]
    public class Customer
    {
        //Properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }
        
        
    }
}
