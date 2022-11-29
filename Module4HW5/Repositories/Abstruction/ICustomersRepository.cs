using Module4HW5.Data.Entities;
using Module4HW5.Models;

namespace Module4HW5.Repositories.Abstruction;

public interface ICustomersRepository
{
    Task<int> CreateCustomerAsync(Customer customer);
    Task<CustomersEntity?> UpdateCustomerAsync(CustomersEntity customer);
    Task<CustomersEntity?>ReadCustomerAsync(int id);
    Task<bool> DeleteCustomerAsync(int id);
    Task<IEnumerable<CustomersEntity>?> GetOrdersFromCustomersMoreThan4();
}