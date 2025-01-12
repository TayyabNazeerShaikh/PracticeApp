using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeApp.Core.Entities;
using PracticeApp.Core.Interfaces;

namespace PracticeApp.Core.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _productRepository.GetAllAsync();
        public async Task<Product> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id);
        public async Task AddAsync(Product product) => await _productRepository.AddAsync(product);
        public async Task UpdateAsync(Product product) => await _productRepository.UpdateAsync(product);
        public async Task DeleteAsync(int id) => await _productRepository.DeleteAsync(id);
    }
}