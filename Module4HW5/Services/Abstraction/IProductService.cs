using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface IProductService
{
    Task<Product> SaveProductAsync(int id, string name, int categoryID, int supplierID);
    Task<int> UpdateProductAsync(Product product);
    Task<Product> GetProductsAsync(int id);
    Task<bool> DeleteProductAsync(int id);
    Task<IReadOnlyList<Product>?> GetProductsByCategoryID(int categoryID);
}