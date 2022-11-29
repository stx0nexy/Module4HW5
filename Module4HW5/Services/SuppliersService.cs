using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class SuppliersService :BaseDataService<ApplicationDbContext>, ISuppliersService
{
    private readonly ISuppliersRepository _suppliersRepository;
    private readonly ILogger<SuppliersService> _loggerService;
    
    public SuppliersService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ISuppliersRepository suppliersRepository,
        ILogger<SuppliersService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _suppliersRepository = suppliersRepository;
        _loggerService = loggerService;
    }
    
    public async Task<int> SaveSupplierAsync(Supplier supplier)
    {
        await _suppliersRepository.CreateSupplierAsync(supplier);
        _loggerService.LogInformation($"Created supplier with Id = {supplier.SupplierID}");
        return supplier.SupplierID;
    }

    public async Task<Supplier> GetSupplierAsync(int id)
    {
        var result = await _suppliersRepository.ReadSupplierAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded supplier");
            return null!;
        }

        return new Supplier()
        {
            SupplierID = result.SupplierID,
            ContactFName = result.ContactFName,
            ContactLName = result.ContactLName
        };
    }

    public async Task<int> UpdateSupplierAsync(Supplier supplier)
    {
        var result = new SuppliersEntity()
        {
            SupplierID = supplier.SupplierID,
            ContactFName = supplier.ContactFName,
            ContactLName = supplier.ContactLName
        };
        await _suppliersRepository.UpdateSupplierAsync(result);
        _loggerService.LogInformation($"Modified supplier with Id = {result.SupplierID}");
        return result.SupplierID;
    }

    public async Task<bool> DeleteSupplierAsync(int id)
    {
        await _suppliersRepository.DeleteSupplierAsync(id);
        _loggerService.LogInformation($"Delete supplier with Id = {id}");
        return true;
    }

    public async Task<bool> ClearAllProductsInCertainSupplier(int id)
    {
        await _suppliersRepository.ClearAllProductsInCertainSupplier(id);
        _loggerService.LogInformation($"Delete products in supplier with Id = {id}");
        return true;
    }
}