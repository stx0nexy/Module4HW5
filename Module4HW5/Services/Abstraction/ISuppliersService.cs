using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface ISuppliersService
{
    Task<int> SaveSupplierAsync(Supplier supplier);
    Task<int> UpdateSupplierAsync(Supplier supplier);
    Task<Supplier> GetSupplierAsync(int id);
    Task<bool> DeleteSupplierAsync(int id);
    Task<bool> ClearAllProductsInCertainSupplier(int id);
}