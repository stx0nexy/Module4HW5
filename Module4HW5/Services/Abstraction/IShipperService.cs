using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface IShipperService
{
    Task<int> SaveShipperAsync(Shipper shipper);
    Task<int> UpdateShipperAsync(Shipper shipper);
    Task<Shipper> GetShipperAsync(int id);
    Task<bool> DeleteShipperAsync(int id);
    Task<IReadOnlyList<Shipper>> GetOrdersByShipperId(int id);
}