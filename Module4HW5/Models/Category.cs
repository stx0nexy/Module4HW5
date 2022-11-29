namespace Module4HW5.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string? CategoryName { get; set; }
    public IEnumerable<Product>? Products { get; set; } = new List<Product>();
}