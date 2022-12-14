﻿using System;
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
                connection.Execute("dbo.Products_Add @Id, @Price, @Quantity, @Name", entity);
                return entity.Id;
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                connection.Execute("dbo.Products_Delete @Id", new {id});
                return id;
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

        public Product GetById(int id)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                var product = connection.Query<Product>("dbo.Products_GetById @Id", new {Id = id}).ToList();
                return product.FirstOrDefault();
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

        public int Update(Product entity)
        {
            using (IDbConnection connection = conn.GetConnection)
            {
                connection.Execute("dbo.Products_Update @Id, @Price, @Quantity, @Name", entity);
                return entity.Id;
            }

        }
    }
    
        
       
}

