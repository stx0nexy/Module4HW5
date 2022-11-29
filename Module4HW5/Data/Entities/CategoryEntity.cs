using Module4HW5.Models;

namespace Module4HW5.Data.Entities;

public class CategoryEntity
{
    public int CategoryID { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public string? Picture { get; set; }
    public bool? Active { get; set; }
    public List<ProductsEntity>? ProductsEntities { get; set; } = new List<ProductsEntity>();
}