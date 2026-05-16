using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(Product product);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
    Task<Product> GetProductCategoryAsync(int? id);
}
