using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class ProductService: BaseDataService<ApplicationDbContext>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _loggerService;
    
    public ProductService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IProductRepository productRepository,
        ILogger<ProductService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _productRepository = productRepository;
        _loggerService = loggerService;
    }

    public async Task<Product> GetProductsAsync( int id)
    {
        var result = await _productRepository.ReadProductsAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded categories");
            return null!;
        }

        return new Product()
        {
            ProductID = result.ProductID,
            ProductName = result.ProductName
        };
    }

    public async Task<Product> SaveProductAsync(int id, string name, int categoryID, int supplierID)
    {
        var result = await _productRepository.CreateProductAsync(id, name,categoryID, supplierID);
        _loggerService.LogInformation($"Created product with Id = {result.ProductID}");
        return new Product()
        {
            ProductID = result.ProductID,
            ProductName = result.ProductName
        };
    }

    public async Task<int> UpdateProductAsync(Product product)
    {
        var result = new ProductsEntity()
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            CategoryID = product.CategoyID
        };
        await _productRepository.UpdateProductAsync(result);
        _loggerService.LogInformation($"Update product with Id = {result.ProductID}");
        return result.ProductID;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        await _productRepository.DeleteProductAsync(id);
        _loggerService.LogInformation($"Delete product with Id = {id}");
        return true;
    }

    public async Task<IReadOnlyList<Product>?> GetProductsByCategoryID(int categoryID)
    {
        var result = await _productRepository.GetProductsByCategoryID(categoryID);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded products in category = {categoryID}");
            return null!;
        }

        return result.Select(s => new Product()
        {
            ProductID = s.ProductID,
            ProductName = s.ProductName,
            CategoyID = s.CategoryID
        }).ToList();
    }
}