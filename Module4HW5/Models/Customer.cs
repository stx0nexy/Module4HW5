namespace Module4HW5.Models;

public class Customer
{
    public int CustomerID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public IEnumerable<Order>? Orders { get; set; }
}