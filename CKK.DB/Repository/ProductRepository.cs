using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Dapper;

namespace CKK.DB.Repository
{
    public class ProductRepository<Product> : IProductRepository<Product> where Product : CKK.Logic.Models.Product
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
                var product = connection.Execute("dbo.Products_Add @Id, @Price, @Quantity, @Name", entity);
                return product;
            }
        }

        public async Task<int> AddAsync(Product entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var productTask = await Task.Run( () => connection.Execute("dbo.Products_Add @Id, @Price, @Quantity, @Name", entity));
                return productTask;
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var product = connection.Execute("dbo.Products_Delete @Id", new {id});
                return product;
            }

        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var productTask = await Task.Run( () =>connection.Execute("dbo.Products_Delete @Id", new { id }));
                return productTask;
            }

        }

        public List<Product> GetAll()
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var product = connection.Query<Product>("dbo.Products_GetAll").ToList();
                return product;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var productTask = await Task.Run( () => connection.Query<Product>("dbo.Products_GetAll").ToList());
                return productTask;
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var product = connection.Query<Product>("dbo.Products_GetById @Id", new {Id = id}).ToList();
                return product.FirstOrDefault();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var productTask = await Task.Run( () => connection.Query<Product>("dbo.Products_GetById @Id", new { Id = id }).ToList());
                return productTask.FirstOrDefault();
            }
        }

        public List<Product> GetByName(string name)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var product = connection.Query<Product>("dbo.Products_GetByName @Name", new { Name = name }).ToList();
                return product;
            }
        }
        public async Task<List<Product>> GetByNameAsync(string name)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var productTask = await Task.Run( () => connection.Query<Product>("dbo.Products_GetByName @Name", new { Name = name }).ToList());
                return productTask;
            }
        }


        public int Update(Product entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var product = connection.Execute("dbo.Products_Update @Id, @Price, @Quantity, @Name", entity);
                return product;
            }

        }

        public async Task<int> UpdateAsync(Product entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var productTask = await Task.Run( () => connection.Execute("dbo.Products_Update @Id, @Price, @Quantity, @Name", entity));
                return productTask;
            }

        }
    }
    
        
       
}

