using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CategoryService> _loggerService;
    
    public CategoryService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICategoryRepository categoryRepository,
        ILogger<CategoryService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _categoryRepository = categoryRepository;
        _loggerService = loggerService;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        var result = await _categoryRepository.ReadCategoryAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded categories");
            return null!;
        }

        return new Category()
        {
            CategoryID = result.CategoryID,
            CategoryName = result.CategoryName
        };
    }

    public async Task<int> UpdateCategoryAsync(Category category)
    {
        var result = new CategoryEntity()
        {
            CategoryID = category.CategoryID,
            CategoryName = category.CategoryName
        };
        await _categoryRepository.UpdateCategoryAsync(result);
        _loggerService.LogInformation($"Modified category with Id = {result.CategoryID}");
        return result.CategoryID;
    }

    public async Task<int> SaveCategoryAsync(Category category)
    {
        await _categoryRepository.CreateCategoryAsync(category);
        _loggerService.LogInformation($"Created category with Id = {category.CategoryID}");
        return category.CategoryID;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteCategoryAsync(id);
        _loggerService.LogInformation($"Delete category with Id = {id}");
        return true;
    }
}