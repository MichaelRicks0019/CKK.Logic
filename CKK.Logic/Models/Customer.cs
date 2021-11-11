using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    class Customer
    {
        private int id;
        private string name;
        private string address; 

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                Id = id;
            }
        }
        
        public string Name
        {
           get
           {
            return name;
           }
           set
           {
            Name = name;
           }
        }

        public string Address
        {
            get 
            {
                return address;
            }
            set
            {
                Address = address;
            }
        }
        
    }
}
