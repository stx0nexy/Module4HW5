using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class ShipperService :BaseDataService<ApplicationDbContext>, IShipperService
{
    private readonly IShipperRepository _shipperRepository;
    private readonly ILogger<ShipperService> _loggerService;
    
    public ShipperService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IShipperRepository shipperRepository,
        ILogger<ShipperService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _shipperRepository = shipperRepository;
        _loggerService = loggerService;
    }
    
    public async Task<int> SaveShipperAsync(Shipper shipper)
    {
        await _shipperRepository.CreateShipperAsync(shipper);
        _loggerService.LogInformation($"Created shipper with Id = {shipper.ShipperID}");
        return shipper.ShipperID;
    }

    public async Task<Shipper> GetShipperAsync(int id)
    {
        var result = await _shipperRepository.ReadShipperAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded shippers");
            return null!;
        }

        return new Shipper()
        {
            ShipperID = result.ShipperID,
            CompanyName = result.CompanyName
        };
    }

    public async Task<int> UpdateShipperAsync(Shipper shipper)
    {
        var result = new ShippersEntity()
        {
            ShipperID = shipper.ShipperID,
            CompanyName = shipper.CompanyName
        };
        await _shipperRepository.UpdateShipperAsync(result);
        _loggerService.LogInformation($"Modified shipper with Id = {result.ShipperID}");
        return result.ShipperID;
    }

    public async Task<bool> DeleteShipperAsync(int id)
    {
        await _shipperRepository.DeleteShipperAsync(id);
        _loggerService.LogInformation($"Delete shipper with Id = {id}");
        return true;
    }

    public async Task<IReadOnlyList<Shipper>> GetOrdersByShipperId(int id)
    {
        var result = await _shipperRepository.GetOrdersByShipperId(id);
        if (result == null)
        {
            _loggerService.LogWarning($"Not founded orders by shipper id = {id} ");
            return null!;
        }

        return result.Select(r => new Shipper()
        {
            ShipperID = r.ShipperID,
            CompanyName = r.CompanyName,
            Orders = r.OrdersEntities.Select(e => new Order()
                {
                    OrderID = e.OrderID,
                    CustomerID = e.CustomerID,
                    PaymentID = e.PaymentID,
                    ShipperID = e.ShipperID,
                    OrderNumber = e.OrderNumber
                }
            )
        }).ToList();
    }
}