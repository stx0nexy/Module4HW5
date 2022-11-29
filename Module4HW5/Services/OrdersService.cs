using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class OrdersService: BaseDataService<ApplicationDbContext>, IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly ILogger<OrdersService> _loggerService;
    
    public OrdersService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrdersRepository ordersRepository,
        ILogger<OrdersService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _ordersRepository = ordersRepository;
        _loggerService = loggerService;
    }

    public async Task<Order> GetOrderAsync( int id)
    {
        var result = await _ordersRepository.ReadOrderAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded orders");
            return null!;
        }

        return new Order()
        {
            OrderID = result.OrderID,
            OrderNumber = result.OrderNumber,
            CustomerID = result.CustomerID,
            PaymentID = result.PaymentID,
            ShipperID = result.ShipperID
        };
    }

    public async Task<Order> SaveOrderAsync(int id, int number, int customerID, int paymentID, int shipperID)
    {
        var result = await _ordersRepository.CreateOrderAsync(id, number,customerID,paymentID,shipperID);
        _loggerService.LogInformation($"Created order with Id = {result.OrderID}");
        return new Order()
        {
            OrderID = result.OrderID,
            OrderNumber = result.OrderNumber,
            CustomerID = result.CustomerID,
            PaymentID = result.PaymentID,
            ShipperID = result.ShipperID
        };
    }

    public async Task<int> UpdateOrderAsync(Order order)
    {
        var result = new OrdersEntity()
        {
            OrderID = order.OrderID,
            OrderNumber = order.OrderNumber,
            CustomerID = order.CustomerID,
            PaymentID = order.PaymentID,
            ShipperID = order.ShipperID
        };
        await _ordersRepository.UpdateOrderAsync(result);
        _loggerService.LogInformation($"Update order with Id = {result.OrderID}");
        return result.OrderID;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        await _ordersRepository.DeleteOrderAsync(id);
        _loggerService.LogInformation($"Delete order with Id = {id}");
        return true;
    }

    public async Task<IReadOnlyList<Order>?> GetOrdersFromCustomer(int customerId)
    {
        var result = await _ordersRepository.GetOrdersFromCustomer(customerId);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded orders from customer with id = {customerId}");
            return null!;
        }

        return result.Select(r => new Order()
        {
            OrderID = r.OrderID,
            CustomerID = r.CustomerID,
            PaymentID = r.PaymentID,
            ShipperID = r.ShipperID,
            OrderNumber = r.OrderNumber,
            OrderDetails = r.OrderDetailsEntities.Select(d => new OrderDetail()
            {
                OrderDetailID = d.OrderDetailID,
                OrderID = d.OrderID,
                OrderNumber = d.OrderNumber,
                ProductID = d.ProductID
            })
        }).ToList();
    }
}