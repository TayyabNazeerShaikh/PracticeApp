using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using PracticeApp.Core.Entities;
using PracticeApp.Core.Interfaces;

namespace PracticeApp.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqliteConnection CreateConnection() => new SqliteConnection(_connectionString);

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();

            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();

                using (var command = new SqliteCommand("SELECT * FROM Products", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2)
                            });
                        }
                    }
                }
            }

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            Product? product = null;

            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();

                using (var command = new SqliteCommand("SELECT * FROM Products WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2)
                            };
                        }
                    }
                }
            }

            return product;
        }

        public async Task AddAsync(Product product)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();

                using (var command = new SqliteCommand("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Product product)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();

                using (var command = new SqliteCommand("UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();

                using (var command = new SqliteCommand("DELETE FROM Products WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<bool> CheckDatabaseExistenceAsync()
        {
            var fileInfo = new System.IO.FileInfo(_connectionString);
            return fileInfo.Exists;
        }

        public async Task<bool> EnsureDatabaseCreatedAsync()
        {
            var fileInfo = new System.IO.FileInfo(_connectionString);
            if (!fileInfo.Exists)
            {
                using (var connection = CreateConnection())
                {
                    await connection.OpenAsync();
                    var createTableCommand = @"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Price REAL NOT NULL
                        );";
                    using (var command = new SqliteCommand(createTableCommand, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            return true;
        }
    }
}