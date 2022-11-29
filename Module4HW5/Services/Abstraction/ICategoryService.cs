using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface ICategoryService
{
    Task<int> SaveCategoryAsync(Category category);
    Task<int> UpdateCategoryAsync(Category category);
    Task<Category> GetCategoryAsync(int id);
    Task<bool> DeleteCategoryAsync(int id);   
}