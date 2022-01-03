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

        //GetId Method
        public int GetId()
        {
            return id;
        }
        public void SetId(int customerId)
        {
            id = customerId;
        }
        //GetName Method
        public string GetName()
        {
            return name;
        }
        public void SetName(string customerName)
        {
            name = customerName;
        }
        //GetAddress Methos
        public string GetAddress()
        {
            return address;
        }
        public void SetAddress(string customerAddress)
        {
            address = customerAddress;
        }
    }   
}
