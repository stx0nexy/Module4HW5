namespace Module4HW5.Data.Entities;

public class ShippersEntity
{
    public int ShipperID { get; set; }
    public string? CompanyName { get; set; }
    public string? Phone { get; set; }
    public List<OrdersEntity>? OrdersEntities { get; set; } = new List<OrdersEntity>();
}