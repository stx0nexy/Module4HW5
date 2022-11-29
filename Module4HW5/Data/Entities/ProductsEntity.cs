namespace Module4HW5.Data.Entities;

public class ProductsEntity
{
    public int ProductID { get; set; }
    public string? SKU { get; set; }
    public int? IDSKU { get; set; }
    public int? VendorProductID { get; set; }
    public string ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public int? SupplierID { get; set; }
    public SuppliersEntity? SuppliersEntity { get; set; }
    public int? CategoryID { get; set; }
    public CategoryEntity? CategoryEntity { get; set; }
    public string? QuantityPerUnit { get; set; }
    public string? UnitPrice { get; set; }
    public string? MSRP { get; set; }
    public string? AvailableSize { get; set; }
    public string? AvailableColors { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
    public string? Discount { get; set; }
    public string? UnitWeight { get; set; }
    public string? UnitsInStock { get; set; }
    public string? UnitsOnOrder { get; set; }
    public string? ReorderLevel { get; set; }
    public string? ProductAvailable { get; set; }
    public string? DiscountAvailable { get; set; }
    public string? CurrentOrder { get; set; }
    public string? Picture { get; set; }
    public string? Ranking { get; set; }
    public string? Note { get; set; }
    public List<OrderDetailsEntity>? OrderDetailsEntities { get; set; } = new List<OrderDetailsEntity>();
}