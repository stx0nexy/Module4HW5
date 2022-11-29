namespace Module4HW5.Data.Entities;

public class OrderDetailsEntity
{
    public int? OrderID { get; set; }
    public OrdersEntity? OrdersEntity { get; set; }
    public int? ProductID { get; set; }
    public ProductsEntity? ProductsEntity { get; set; }
    public int? OrderNumber { get; set; }
    public int? Price { get; set; }
    public int? Quantity { get; set; }
    public string? Discount { get; set; }
    public string? Total { get; set; }
    public string? IDSKU { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
    public string? Fulfilled { get; set; }
    public DateTime? ShipDate { get; set; }
    public int OrderDetailID { get; set; }
    public DateTime? BillDate { get; set; }
}