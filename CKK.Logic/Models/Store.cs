using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int id;
        private string name;
        private List<StoreItem> items;

        //Constructor with initialized list
        public Store ()
        {
            items = new List<StoreItem>();
        }
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
                product1 = storeProduct;
            }
            else if (product2 == null)
            {
                product2 = storeProduct;
            }
            else if (product3 == null )
            {
                product3 = storeProduct;
            }
            else 
            {
                
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
                    return null;
            }
        }
        //Find an item using the id
        public Product FindStoreItemById(int idFromStore)
        {
            if (product1.GetId() == idFromStore)
            {
                return product1;
            }
            if (product2.GetId() == idFromStore)
            {
                return product2;
            }
            if (product3.GetId() == idFromStore)
            {
                return product3;
            }
                return null;
        }
    }
}
