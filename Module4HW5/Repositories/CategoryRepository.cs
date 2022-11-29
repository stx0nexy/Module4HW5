using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    public async Task<CategoryEntity?> ReadCategoryAsync(int id)
    { 
        return await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryID == id);
    }

    public async Task<int> CreateCategoryAsync(Category category)
    {
        var result = await _dbContext.Categories.AddAsync(new CategoryEntity()
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            });

        await _dbContext.SaveChangesAsync();
            return result.Entity.CategoryID;
    }

    public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
    {
        if (category.CategoryID != default)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (category);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        CategoryEntity category = await _dbContext.Categories.FirstAsync(c => c.CategoryID == id);
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}