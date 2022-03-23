﻿using System;
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
            if (storeQuantity > 0)
            {
                if (existingProduct != null)
                {
                    existingProduct.SetQuantity(existingProduct.GetQuantity() + storeQuantity);
                }
                else
                {
                    StoreItem item = new StoreItem(storeProduct, storeQuantity);
                    items.Add(item); 
                }
                return existingProduct;
            }
            else
            {
                return null;
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
        //Find an item using the id
        public StoreItem FindStoreItemById(int idFromStore)
        {
            if (idFromStore < 0)
            {
                throw new InvalidIdException($"Id must be greater then 0");
            }
            else
            {
                foreach (StoreItem item in items)
                {
                    if (item.GetProduct().GetId() == idFromStore)
                    {
                        return item;
                    }
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
