using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class OrderDetailsServices : BaseDataService<ApplicationDbContext>, IOrderDetailsServices
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly ILogger<OrderDetailsServices> _loggerService;
    
    public OrderDetailsServices(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrderDetailsRepository orderDetailsRepository,
        ILogger<OrderDetailsServices> loggerService)
        : base(dbContextWrapper, logger)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _loggerService = loggerService;
    }

    public async Task<OrderDetail> GetOrderDetailAsync( int id)
    {
        var result = await _orderDetailsRepository.ReadOrderDetailAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded order details");
            return null!;
        }

        return new OrderDetail()
        {
            OrderDetailID = result.OrderDetailID,
            OrderNumber = result.OrderNumber,
            ProductID = result.ProductID,
            OrderID = result.OrderID
            
        };
    }

    public async Task<OrderDetail> SaveOrderDetailAsync(int id, int productID, int orderID)
    {
        var result = await _orderDetailsRepository.CreateOrderDetailAsync(id, productID,orderID);
        _loggerService.LogInformation($"Created order detail with Id = {result.OrderDetailID}");
        return new OrderDetail()
        {
            OrderDetailID = result.OrderDetailID,
            OrderNumber = result.OrderNumber,
            ProductID = result.ProductID,
            OrderID = result.OrderID
        };
    }

    public async Task<int> UpdateOrderDetailAsync(OrderDetail orderDetail)
    {
        var result = new OrderDetailsEntity()
        {
            OrderDetailID = orderDetail.OrderDetailID,
            OrderNumber = orderDetail.OrderNumber,
            ProductID = orderDetail.ProductID,
            OrderID = orderDetail.OrderID
        };
        await _orderDetailsRepository.UpdateOrderDetailAsync(result);
        _loggerService.LogInformation($"Update order detail with Id = {result.OrderDetailID}");
        return result.OrderDetailID;
    }

    public async Task<bool> DeleteOrderDetailAsync(int id)
    {
        await _orderDetailsRepository.DeleteOrderDetailAsync(id);
        _loggerService.LogInformation($"Delete order detail with Id = {id}");
        return true;
    }

    
}