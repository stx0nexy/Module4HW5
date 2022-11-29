using Module4HW5.Data.Entities;
using Module4HW5.Models;

namespace Module4HW5.Repositories.Abstruction;

public interface ICategoryRepository
{ 
    Task<int> CreateCategoryAsync(Category category);
    Task<CategoryEntity?> UpdateCategoryAsync(CategoryEntity category);
    Task<CategoryEntity?>ReadCategoryAsync(int id);
    Task<bool> DeleteCategoryAsync(int id);
}