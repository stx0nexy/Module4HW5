using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface IOrdersService
{
    Task<Order> SaveOrderAsync(int id, int number, int customerID, int paymentID, int shipperID);
    Task<int> UpdateOrderAsync(Order order);
    Task<Order> GetOrderAsync(int id);
    Task<bool> DeleteOrderAsync(int id);
    Task<IReadOnlyList<Order>?> GetOrdersFromCustomer (int customerId);
}