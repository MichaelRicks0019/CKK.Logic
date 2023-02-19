using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        private decimal price;

        [Required]
        public decimal Price 
        {   get 
            {
                return price;
            } 
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Price cannot be less that zero");
                }
                else
                {
                    price = value;
                }
            } 
        }

        [Required]
        public int Quantity { get; set; }

        public override String ToString() => String.Format("Id: {0}  Name: {1}  Price: {2:C}  Quantity: {3}", Id, Name, Price, Quantity);
    }
}
