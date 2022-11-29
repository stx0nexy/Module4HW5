using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderDetailsRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<OrderDetailsEntity> CreateOrderDetailAsync(int id, int productID, int orderID)
    {
        var orderDetail = new OrderDetailsEntity()
        {
            OrderDetailID = id,
            ProductID = productID,
            OrderID = orderID
        };

        var result = await _dbContext.OrderDetails.AddAsync(orderDetail);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }
    public async Task<OrderDetailsEntity> UpdateOrderDetailAsync(OrderDetailsEntity orderDetail)
    {
        if (orderDetail.OrderDetailID != default)
        {
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (orderDetail);
    }
    
    public async Task<OrderDetailsEntity> ReadOrderDetailAsync(int id)
    {
        return await _dbContext.OrderDetails.FirstOrDefaultAsync(f => f.OrderDetailID == id);
    }

    public async Task<bool> DeleteOrderDetailAsync(int id)
    {
        OrderDetailsEntity orderDetail = await _dbContext.OrderDetails.FirstAsync(c => c.OrderDetailID == id);
        _dbContext.OrderDetails.Remove(orderDetail);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}