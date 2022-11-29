namespace Module4HW5.Models;

public class Order
{
    public int OrderID { get; set; }
    public int? OrderNumber { get; set; }
    public int? CustomerID { get; set; }
    public int? PaymentID { get; set; }
    public int? ShipperID { get; set; }
    public Customer? Customer { get; set; }
    public IEnumerable<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    public Payment? Payments { get; set; }
}