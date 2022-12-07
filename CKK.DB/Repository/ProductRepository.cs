using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic.Models;

namespace CKK.DB.Repository
{
    class ProductRepository<Product> : IProductRepository<Product> where Product : CKK.Logic.Models.Product
    {
        public IConnectionFactory conn;
        public ProductRepository(IConnectionFactory Conn) 
        {
             conn = Conn;
        }

        public int Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
    
        
       
}

