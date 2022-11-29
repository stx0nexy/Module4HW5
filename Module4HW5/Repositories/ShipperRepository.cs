using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class ShipperRepository : IShipperRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ShipperRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    
    public async Task<int> CreateShipperAsync(Shipper shipper)
    {
        var result = await _dbContext.Shippers.AddAsync(new ShippersEntity()
        {
            ShipperID = shipper.ShipperID,
            CompanyName = shipper.CompanyName
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.ShipperID;
    }
    public async Task<ShippersEntity> UpdateShipperAsync(ShippersEntity shipper)
    {
        if (shipper.ShipperID != default)
        {
            _dbContext.Entry(shipper).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (shipper);
    }
    public async Task<ShippersEntity?> ReadShipperAsync(int id)
    { 
        return await _dbContext.Shippers.FirstOrDefaultAsync(f => f.ShipperID == id);
    }

    public async Task<bool> DeleteShipperAsync(int id)
    {
        ShippersEntity shippers = await _dbContext.Shippers.FirstAsync(c => c.ShipperID == id);
        _dbContext.Shippers.Remove(shippers);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ShippersEntity>> GetOrdersByShipperId(int id)
    {
        return await _dbContext.Shippers.Include(s => s.OrdersEntities)
            .Where(e => e.ShipperID == id).ToListAsync();
    }
}