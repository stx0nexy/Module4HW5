namespace Module4HW5.Models;

public class Payment
{
    public int PaymentID { get; set; }
    public string? PaymentType { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}