using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Persistance.Interfaces;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;
using CKK.Persistance;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace CKK.Persistance.Models
{
    /*
    public class FileStore : IStore, ISavable, ILoadable
    {

        
        private List<StoreItem> items = new List<StoreItem>();
        public readonly string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        public readonly string filePathCreate = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance";
        int[] idValues = Enumerable.Range(1000, 9999).ToArray();
        int idValuesCounter = 0;


        public FileStore()
        {
            CreatePath();
        }

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
                else if (existingProduct.GetQuantity() - storeQuantity > 0)
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

            foreach (StoreItem item in list)
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


        //Saves File to C:\Users\<username>\Documents\Persistance\StoreItems.dat
        public void Save()
        {
            using (var fsItemsCreate = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fsItemsCreate, items);
            }
            
        }

        //Loads File from C:\Users\<username>\Documents\Persistance\StoreItems.dat
        public void Load()
        {
            using (var fsItemsOpen = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                items = (List<StoreItem>)bf.Deserialize(fsItemsOpen);
            }
;     
            
        }

        private void CreatePath()
        {
            Directory.CreateDirectory(filePathCreate);  
        }
    
    }
    */
}
