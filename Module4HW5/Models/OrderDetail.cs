namespace Module4HW5.Models;

public class OrderDetail
{
    public int OrderDetailID { get; set; }
    public int? ProductID { get; set; }
    public int? OrderID { get; set; }
    public int? OrderNumber { get; set; }
    public string? Price { get; set; }
    public DateTime? BillDate { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}