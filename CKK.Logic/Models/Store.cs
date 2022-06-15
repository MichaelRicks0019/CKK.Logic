using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        private List<StoreItem> items;
        int[] idValues = Enumerable.Range(1000, 9999).ToArray();
        int idValuesCounter = 0;

        //Constructor with initialized list
        public Store()
        {
            items = new List<StoreItem>();
        }
        //Get and Set id below
        public int GetId()
        {
            return base.Id;
        }
        public void SetId(int storeId)
        {
            base.Id = storeId;
        }
        //Get and Set name below
        public string GetName()
        {
            return base.Name;
        }
        public void SetName(string storeName)
        {
            base.Name = storeName;
        }

        //Add product to store
        public StoreItem AddStoreItem(Product storeProduct, int storeQuantity)
        {
            if (storeQuantity <= 0)
            {
                throw new InventoryItemStockTooLowException($"Quantity must be greater than 0 or equal to 0");
            }

            var existingProduct = FindStoreItemById(storeProduct.GetId());
            
            if (existingProduct != null)
            {
                existingProduct.SetQuantity(existingProduct.GetQuantity() + storeQuantity);
                if (existingProduct.GetProduct().GetId() == 0)
                {
                    existingProduct.GetProduct().SetId(idValues[idValuesCounter]);
                    idValuesCounter++;
                }
                return existingProduct;
            }
            else
            {
                StoreItem item = new StoreItem(storeProduct, storeQuantity);
                item.Product.SetId(idValues[idValuesCounter]);
                idValuesCounter++;
                items.Add(item);
                return item;
            }
        }

        //Remove product from store
        public StoreItem RemoveStoreItem(int id, int storeQuantity)
        {
            if (storeQuantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(storeQuantity), storeQuantity, $"Quantity must be greater than 0");
            }
            var existingProduct = FindStoreItemById(id);

            if (existingProduct != null)
            {
                if (existingProduct.GetQuantity() - storeQuantity <= 0)
                {
                    existingProduct.SetQuantity(0);
                }
                else if(existingProduct.GetQuantity() - storeQuantity > 0)
                {
                    existingProduct.SetQuantity(existingProduct.GetQuantity() - storeQuantity);
                }
                return existingProduct;
            }
            else
            {
                throw new ProductDoesNotExistException($"Product does not exist");
            }
        }

        //Completely deletes the product
        public StoreItem DeleteStoreItem(int id)
        {
            
            if (id < 0)
            {
               throw new ArgumentOutOfRangeException(nameof(id), id, $"Id number must be greater than 0");
            }
            var existingProduct = FindStoreItemById(id);

             if (existingProduct != null)
             {
                items.Remove(existingProduct);
             }
             else
             {
                throw new ProductDoesNotExistException($"Product does not exist");
             }
            return existingProduct;
            
        }

        //Find an item using the id
        public StoreItem FindStoreItemById(int idFromStore)
        {
            if (idFromStore < 0)
            {
                throw new InvalidIdException($"Id must be greater then 0");
            }
            foreach (StoreItem item in items)
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
