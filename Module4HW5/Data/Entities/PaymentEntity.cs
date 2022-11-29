namespace Module4HW5.Data.Entities;

public class PaymentEntity
{
    public int PaymentID { get; set; }
    public string? PaymentType { get; set; }
    public bool? Allowed { get; set; }
    public List<OrdersEntity>? OrdersEntities { get; set; } = new List<OrdersEntity>();
}