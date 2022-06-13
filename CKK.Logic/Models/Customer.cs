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
    public class Customer : Entity
    {
        private string address;

        //GetId Method
        public int GetId()
        {
            return base.Id;
        }
        public void SetId(int customerId)
        {
            base.Id = customerId;
        }
        //GetName Method
        public string GetName()
        {
            return base.Name;
        }
        public void SetName(string customerName)
        {
            base.Name = customerName;
        }
        //Address Property
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    }
}
