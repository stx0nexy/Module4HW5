namespace Module4HW5.Data.Entities;

public class OrdersEntity
{
    public int OrderID { get; set; }
    public int? CustomerID { get; set; }
    public CustomersEntity? CustomersEntity { get; set; }
    public int? OrderNumber { get; set; }
    public int? PaymentID { get; set; }
    public PaymentEntity? PaymentEntity { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public int? ShipperID { get; set; }
    public ShippersEntity? ShippersEntity { get; set; }
    public string? Freight { get; set; }
    public string? SalesTax { get; set; }
    public DateTime? Timestamp { get; set; }
    public bool? TransactStatus { get; set; }
    public string? ErrLoc { get; set; }
    public string? ErrMsg { get; set; }
    public string? Fulfilled { get; set; }
    public string? Deleted { get; set; }
    public string? Paid { get; set; }
    public DateTime? PaymentDate { get; set; }
    public List<OrderDetailsEntity>? OrderDetailsEntities { get; set; } = new List<OrderDetailsEntity>();
}