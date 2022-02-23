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
        public StoreItem AddStoreItem(Product storeProduct, int storeQuantity)
        {
            bool itemFound = false;
            foreach (StoreItem item in items)
            {
                if (storeQuantity <= 0)
                {
                    return null;
                }
                else if (item.GetProduct() == storeProduct && storeQuantity > 0)
                {
                    itemFound = true;
                    item.SetQuantity(item.GetQuantity() + storeQuantity);
                    return item;
                }
            }
            if (itemFound == false)
            {
                StoreItem item = new StoreItem(storeProduct, storeQuantity);
                items.Add(item);
                return item;
            }
            else
            {
                return null;
            }
            
        }
        //Remove product from store
        public StoreItem RemoveStoreItem(int id, int storeQuantity)
        {
            foreach (StoreItem item in items)
            {
                if (item.GetProduct().GetId() == id && item.GetQuantity() - storeQuantity <= 0)
                {
                    item.SetQuantity(0);
                    return item;
                }
                else if (item.GetProduct().GetId() == id && item.GetQuantity() - storeQuantity > 0)
                {
                    item.SetQuantity(item.GetQuantity() - storeQuantity);
                    return item;
                }
            }
            return null;
        }
        //Find an item using the id
        public StoreItem FindStoreItemById(int idFromStore)
        {
            foreach(StoreItem item in items)
            {
                if (item.GetProduct().GetId() == idFromStore)
                {
                    return item;
                }
            }
            return null;
        }
        //Returns store items
        public List<StoreItem> GetStoreItems()
        {
            return items;
        }


    }
}
