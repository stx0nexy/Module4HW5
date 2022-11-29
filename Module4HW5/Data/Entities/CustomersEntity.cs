namespace Module4HW5.Data.Entities;

public class CustomersEntity
{
    public int CustomerID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Class { get; set; }
    public int? Room { get; set; }
    public string? Building { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? VoiceMail { get; set; }
    public string? Password { get; set; }
    public string? CreditCard { get; set; }
    public string? CreditCardTypeID { get; set; }
    public string? CardExpMo { get; set; }
    public string? CardExpYr { get; set; }
    public string? BillingAddress { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingRegion { get; set; }
    public string? BillingPostalCode { get; set; }
    public string? BillingCountry { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }
    public DateTime? DateEntered { get; set; }
    public List<OrdersEntity>? OrdersEntities { get; set; } = new List<OrdersEntity>();
    
}