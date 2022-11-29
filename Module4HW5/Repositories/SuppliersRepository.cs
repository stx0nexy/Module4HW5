using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class SuppliersRepository : ISuppliersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SuppliersRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    
    public async Task<int> CreateSupplierAsync(Supplier supplier)
    {
        var result = await _dbContext.Suppliers.AddAsync(new SuppliersEntity()
        {
            SupplierID = supplier.SupplierID,
            ContactFName = supplier.ContactFName,
            ContactLName = supplier.ContactLName
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.SupplierID;
    }
    public async Task<SuppliersEntity> UpdateSupplierAsync(SuppliersEntity supplier)
    {
        if (supplier.SupplierID != default)
        {
            _dbContext.Entry(supplier).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (supplier);
    }
    public async Task<SuppliersEntity?> ReadSupplierAsync(int id)
    { 
        return await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.SupplierID == id);
    }

    public async Task<bool> DeleteSupplierAsync(int id)
    {
        SuppliersEntity suppliers = await _dbContext.Suppliers.FirstAsync(c => c.SupplierID == id);
        _dbContext.Suppliers.Remove(suppliers);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearAllProductsInCertainSupplier(int id)
    { 
        await _dbContext.Suppliers.Where(w => w.SupplierID == id)
            .Select(p => p.ProductsEntities).ForEachAsync(e => e.Clear());
        return true;
    }
}