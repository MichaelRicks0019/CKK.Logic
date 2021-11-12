using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class Customer
    {
        private int id;
        private string name;
        private string address; 

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Name
        {
           get { return name; }
           set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        
    }
}
