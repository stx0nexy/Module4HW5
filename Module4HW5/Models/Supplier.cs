namespace Module4HW5.Models;

public class Supplier
{
    public int SupplierID { get; set; }
    public string? ContactFName { get; set; }
    public string? ContactLName { get; set; }
    public string? City { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}