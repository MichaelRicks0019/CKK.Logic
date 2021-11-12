using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class Product
    {
        private int id;
        private string name;
        private decimal price;

        //Get and set ID
        public int GetId()
        {
            return id;
        }
        public void SetId(int productId)
        {
            id = productId;
        }
        //Get and Set Name
        public string GetName()
        {
            return name;
        }
        public void SetName(string productName)
        {
            name = productName;
        }
        //Get and Set Price
        public decimal GetPrice()
        {
            return price;
        }
        public void SetPrice(decimal productPrice)
        {
            price = productPrice;
        }
        
    }
}
