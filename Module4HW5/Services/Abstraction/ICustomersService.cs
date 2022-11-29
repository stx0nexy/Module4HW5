using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface ICustomersService
{
    Task<int> SaveCustomerAsync(Customer customer);
    Task<int> UpdateCustomerAsync(Customer customer);
    Task<Customer> GetCustomerAsync(int id);
    Task<bool> DeleteCustomerAsync(int id);  
    Task<IReadOnlyList<Customer>?> GetOrdersFromCustomersMoreThan4();
}