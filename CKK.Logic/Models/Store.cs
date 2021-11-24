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
            id = storeId;
        }
        //Get and Set name below
        public string GetName()
        {
            return name;
        }
        public void SetName(string storeName)
        {
            name = storeName;
        }
        //Add product to store
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
                Console.WriteLine("There is no available spot to add an item");
            }
            
        }
        //Remove product from store
        public void RemoveStoreItem(int productNum)
        {
            switch (productNum)
            {
                case 1:
                    product1 = null;
                    break;
                case 2:
                    product2 = null;
                    break;
                case 3:
                    product3 = null;
                    break;
                default:
                    Console.WriteLine("An incorrect product number was entered.");
                    break;
            }
        }
        //Returns store item
        public Product GetStoreItem(int productNum)
        {
            switch (productNum)
            {
                case 1:
                    return product1;
                case 2:
                    return product2;
                case 3:
                    return product3;
                default:
                    Console.WriteLine("The product number that was entered doesn't exist.");
                    return null;
            }
        }
        //Find an item using the id
        public Product FindStoreItemById(int idFromStore)
        {
            if (idFromStore == product1.GetId())
            {
                return product1;
            }
            else if (idFromStore == product2.GetId())
            {
                if (product2.GetId() == product1.GetId())
                {
                    return product1;
                }
                else
                {
                    return product2;
                }
            }
            else if (idFromStore == product3.GetId())
            {
                if (product3.GetId() == product1.GetId())
                {
                    return product1;
                }
                else if (product3.GetId() == product2.GetId())
                {
                    return product2;
                }
                else
                {
                    return product3;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
