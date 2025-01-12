using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using FluentAssertions;
using PracticeApp.Core.Entities;
using PracticeApp.Core.Interfaces;
using PracticeApp.Core.Services;

namespace PracticeApp.UnitTests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0m },
                new Product { Id = 2, Name = "Product 2", Price = 20.0m }
            };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllAsync();

            // Assert
            result.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0m };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.GetByIdAsync(1);

            // Assert
            result.Should().BeEquivalentTo(product);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var product = new Product { Id = 0, Name = "New Product", Price = 15.0m };

            // Act
            await _productService.AddAsync(product);

            // Assert
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Updated Product", Price = 25.0m };

            // Act
            await _productService.UpdateAsync(product);

            // Assert
            _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryMethod()
        {
            // Arrange
            var productId = 1;

            // Act
            await _productService.DeleteAsync(productId);

            // Assert
            _mockRepo.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}