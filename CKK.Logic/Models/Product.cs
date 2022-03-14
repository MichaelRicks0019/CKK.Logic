using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
     public class Product : Entity
    {
        private decimal price;

        //Get and set ID
        public int GetId()
        {
            return base.Id;
        }
        public void SetId(int productId)
        {
            base.Id = productId;
        }
        //Get and Set Name
        public string GetName()
        {
            return base.Name;
        }
        public void SetName(string productName)
        {
            base.Name = productName;
        }
        //Get and Set Price
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
    }
}
