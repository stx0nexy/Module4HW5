using Module4HW5.Data.Entities;

namespace Module4HW5.Repositories.Abstruction;

public interface IOrdersRepository
{
    Task<OrdersEntity> CreateOrderAsync(int id, int number, int customerID, int paymentID, int shipperID);
    Task<OrdersEntity> UpdateOrderAsync(OrdersEntity order);
    Task<OrdersEntity?> ReadOrderAsync(int id);
    Task<bool> DeleteOrderAsync(int id);
    Task<IEnumerable<OrdersEntity>?> GetOrdersFromCustomer (int customerId);
}