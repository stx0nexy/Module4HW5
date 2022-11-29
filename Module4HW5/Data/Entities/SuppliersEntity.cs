namespace Module4HW5.Data.Entities;

public class SuppliersEntity
{
    public int SupplierID { get; set; }
    public string? CompanyName { get; set; }
    public string? ContactFName { get; set; }
    public string? ContactLName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? URL { get; set; }
    public string? PaymentMethods { get; set; }
    public string? DiscountType { get; set; }
    public string? TypeGoods { get; set; }
    public string? Notes { get; set; }
    public bool? DiscountAvailable { get; set; }
    public string? CurrentOrder { get; set; }
    public string? Logo { get; set; }
    public string? SizeURL { get; set; }
    public int? CustomerID { get; set; }
    public List<ProductsEntity>? ProductsEntities { get; set; } = new List<ProductsEntity>();
}