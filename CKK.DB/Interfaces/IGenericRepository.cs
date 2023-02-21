using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IGenericRepository<T>
    {
        //Regular Methods
        //IProductRepository and IOrderRepository inherit this class
        
        //Gets entity by Id
        T GetById(int id);
        //Gets all entities an returns list
        List<T> GetAll();
        //Adds entity to database
        int Add(T entity);
        //Finds entity in database based on Id and replaces it if different
        int Update(T entity);
        //Removes entity from database
        int Delete(int id);

        //Async Methods
        //Performs same acitons as above but asynchronous
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);


    }
}
