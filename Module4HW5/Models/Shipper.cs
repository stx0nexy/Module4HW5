namespace Module4HW5.Models;

public class Shipper
{
    public int ShipperID { get; set; }
    public string? CompanyName { get; set; }
    public IEnumerable<Order>? Orders { get; set; } = new List<Order>();
}