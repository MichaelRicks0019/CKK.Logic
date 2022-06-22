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

        public List<StoreItem> GetAllProductsByName(string name)
        {
            List<StoreItem> list = new List<StoreItem>();
            list = items;
            int stringLength = name.Length;
            string firstLetter = name.Substring(0, 1);

            foreach(StoreItem item in list)
            {
                if (item.GetProduct().GetName() == name)
                {
                    list.Add(item);
                }
            }
            if (list.Count() == 0)
            {
                throw new ProductDoesNotExistException($"The Product with the name {name} was not found");
            }
            return list;
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            List<StoreItem> list = new List<StoreItem>();
            list = items;
            int count = list.Count;

            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count - 1; y++)
                {
                    int yCompare = y + 1;
                    if (list[y].GetQuantity() > list[yCompare].GetQuantity())
                    {
                        Swap(list[y], list[yCompare]);
                    }
                }
                count--;
            }
            return items;
        }

        public List<StoreItem> GetProductsByPrice()
        {
            List<StoreItem> list = new List<StoreItem>();
            list = items;
            int count = list.Count;

            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count - 1; y++)
                {
                    int yCompare = y + 1;
                    if (list[y].GetProduct().Price > list[yCompare].GetProduct().Price)
                    {
                        Swap(list[y], list[yCompare]);
                    }
                }
                count--;
            }
            return items;
        }

        public static void Swap(StoreItem value1, StoreItem value2)
        {
            StoreItem tempStorage = value1;
            value1 = value2;
            value2 = tempStorage;
        }

    }
}
































/*  This was used for GetAllProductByName to get rest of items in alphabetical order....Its not completed. Use if all products are needed.
 *  
 *  foreach(StoreItem item in items)
            {
                if (item.GetProduct().GetName().Contains(firstLetter) == true && item.GetProduct().GetName() != name)
                {
                    list.Add(item);
                }
            }
            for (int x = 0; x < items.Count; x++)
            {
                for (int y = 0; y < items.Count; y++)
                {
                    if (items.)
                }
            }
*/