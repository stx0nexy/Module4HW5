using Module4HW5.Data.Entities;

namespace Module4HW5.Repositories.Abstruction;

public interface IOrderDetailsRepository
{
    Task<OrderDetailsEntity> CreateOrderDetailAsync(int id, int productID, int orderID);
    Task<OrderDetailsEntity> UpdateOrderDetailAsync(OrderDetailsEntity orderDetails);
    Task<OrderDetailsEntity?> ReadOrderDetailAsync(int id);
    Task<bool> DeleteOrderDetailAsync(int id);
}