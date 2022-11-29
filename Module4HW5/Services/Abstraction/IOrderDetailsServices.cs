using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface IOrderDetailsServices
{
    Task<OrderDetail> SaveOrderDetailAsync(int id, int productID, int orderID);
    Task<int> UpdateOrderDetailAsync(OrderDetail orderDetail);
    Task<OrderDetail> GetOrderDetailAsync(int id);
    Task<bool> DeleteOrderDetailAsync(int id);
}