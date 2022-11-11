using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {
        //Properties 
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart Cart { get; set; }

        //Methods
        public int GetId()
        {
            return base.Id;
        }

        public void SetId(int customerId)
        {
            base.Id = customerId;
        }
      
        public string GetName()
        {
            return base.Name;
        }

        public void SetName(string customerName)
        {
            base.Name = customerName;
        }
    }
}
