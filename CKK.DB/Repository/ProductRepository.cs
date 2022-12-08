using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic.Models;
using Dapper;

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
            using (IDbConnection connection = conn.GetConnection)
            {
                List<Product> product = new List<Product> { entity };
                connection.Execute("dbo.Products_Add @Id, @Price, @Quantity, @Name", product);
                return entity.Id;
            }
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

