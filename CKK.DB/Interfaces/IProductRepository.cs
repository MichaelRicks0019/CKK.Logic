using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IProductRepository<Product> : IGenericRepository<Product> where Product : CKK.Logic.Models.Product
    {
        //Regular Methods

        //Returns list of Products
        List<Product> GetByName(string name);

        //Async Methods

        //Same as above but asynchronous
        Task<List<Product>> GetByNameAsync(string name);
    };
}
