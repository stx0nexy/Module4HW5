using Module4HW5.Data.Entities;
using Module4HW5.Models;

namespace Module4HW5.Repositories.Abstruction;

public interface IProductRepository
{
    Task<ProductsEntity> CreateProductAsync(int id, string name, int categoryID, int supplierID);
    Task<ProductsEntity> UpdateProductAsync(ProductsEntity product);
    Task<ProductsEntity?> ReadProductsAsync(int id);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<ProductsEntity>?> GetProductsByCategoryID (int categoryID);
    
}