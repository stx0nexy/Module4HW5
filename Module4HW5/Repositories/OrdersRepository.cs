using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrdersRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<OrdersEntity> CreateOrderAsync(int id, int number, int customerID, int paymentID, int shipperID)
    {
        var order = new OrdersEntity()
        {
            OrderID = id,
            CustomerID = customerID,
            PaymentID = paymentID,
            ShipperID = shipperID
        };

        var result = await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }
    public async Task<OrdersEntity> UpdateOrderAsync(OrdersEntity order)
    {
        if (order.OrderID != default)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (order);
    }
    
    public async Task<OrdersEntity> ReadOrderAsync(int id)
    {
        return await _dbContext.Orders.FirstOrDefaultAsync(f => f.OrderID == id);
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        OrdersEntity order = await _dbContext.Orders.FirstAsync(c => c.OrderID == id);
        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<OrdersEntity>?> GetOrdersFromCustomer(int customerId)
    {
        return await _dbContext.Orders.Include(o =>o.OrderDetailsEntities).Where(f => f.CustomerID == customerId).ToListAsync();
    }
}