using Module4HW5.Data.Entities;
using Module4HW5.Models;

namespace Module4HW5.Repositories.Abstruction;

public interface IShipperRepository
{
    Task<int> CreateShipperAsync(Shipper shipper);
    Task<ShippersEntity?> UpdateShipperAsync(ShippersEntity shipper);
    Task<ShippersEntity?>ReadShipperAsync(int id);
    Task<bool> DeleteShipperAsync(int id);
    Task<IEnumerable<ShippersEntity>> GetOrdersByShipperId(int id);
}