using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeApp.Core.Entities;

namespace PracticeApp.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<bool> CheckDatabaseExistenceAsync();
        Task<bool> EnsureDatabaseCreatedAsync();
    }
}