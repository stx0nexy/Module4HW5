using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<ProductsEntity> ReadProductsAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.ProductID == id);
    }

    public async Task<ProductsEntity> GetProductByIdAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);
    }

    public async Task<ProductsEntity> CreateProductAsync(int id, string name, int categoryID, int supplierID)
    {
        var product = new ProductsEntity()
        {
            ProductID = id,
            ProductName = name,
            CategoryID = categoryID,
            SupplierID = supplierID
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<ProductsEntity> UpdateProductAsync(ProductsEntity product)
    {
        if (product.ProductID != default)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _dbContext.Products.FirstAsync(c => c.ProductID == id);
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ProductsEntity>?> GetProductsByCategoryID(int categoryID)
    {
        return await _dbContext.Products.Where(f => f.CategoryID == categoryID).ToListAsync();
    }
}