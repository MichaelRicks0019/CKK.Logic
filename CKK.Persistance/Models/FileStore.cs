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
    public class FileStore : IStore, ISavable, ILoadable
    {
        private List<StoreItem> items = new List<StoreItem>();
        public readonly string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
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


        //Saves File to C:\Users\<username>\Documents\Persistance\StoreItems.dat
        public void Save()
        {
            FileStream fsItems = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fsItems, items);
        }

        //Loads File from C:\Users\<username>\Documents\Persistance\StoreItems.dat
        public void Load()
        {
            FileStream fsItems = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            items = (List<StoreItem>)bf.Deserialize(fsItems);
        }

        private void CreatePath()
        {
            if (Directory.Exists(filePath))
            {
                throw new Exception("File already Exists");
            }
            else
            {
                Directory.CreateDirectory(filePath);
            }
            
        }

        public void SetItems(List<StoreItem> items)
        {
            this.items = items;
        }
    }
}
