using Module4HW5.Data.Entities;
using Module4HW5.Models;

namespace Module4HW5.Repositories.Abstruction;

public interface ISuppliersRepository
{
    Task<int> CreateSupplierAsync(Supplier payment);
    Task<SuppliersEntity?> UpdateSupplierAsync(SuppliersEntity payment);
    Task<SuppliersEntity?>ReadSupplierAsync(int id);
    Task<bool> DeleteSupplierAsync(int id);
    Task<bool> ClearAllProductsInCertainSupplier(int id);
}