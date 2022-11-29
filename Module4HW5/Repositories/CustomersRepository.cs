using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomersRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    
    public async Task<int> CreateCustomerAsync(Customer customer)
    {
        var result = await _dbContext.Customers.AddAsync(new CustomersEntity()
        {
            CustomerID = customer.CustomerID,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Phone = customer.Phone
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.CustomerID;
    }
    public async Task<CustomersEntity> UpdateCustomerAsync(CustomersEntity customer)
    {
        if (customer.CustomerID != default)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (customer);
    }
    public async Task<CustomersEntity?> ReadCustomerAsync(int id)
    { 
        return await _dbContext.Customers.FirstOrDefaultAsync(f => f.CustomerID == id);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        CustomersEntity customer = await _dbContext.Customers.FirstAsync(c => c.CustomerID == id);
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CustomersEntity>?> GetOrdersFromCustomersMoreThan4()
    {
        return await _dbContext.Customers.Where(s => s.OrdersEntities.Count > 4).ToListAsync();
    }
    
}