using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    class Store
    {
        private int id;
        private string name;
        private Product product1;
        private Product product2;
        private Product product3;

        //Get and Set id below
        public int GetId()
        {
            return id;
        }
        public void SetId(int storeId)
        {
            storeId = id;
        }
        //Get and Set name below
        public string GetName()
        {
            return name;
        }

        public void SetName(string storeName)
        {
            storeName = name;
        }

        public void AddStoreItem(Product storeProduct)
        {
            if (product1 == null)
            {
                storeProduct = product1;
            }
            else if (product2 == null)
            {
                storeProduct = product2;
            }
            else if (product3 == null )
            {
                storeProduct = product3;
            }
            else
            {
                //Put something here maybe
            }
            
        }
    }
}
