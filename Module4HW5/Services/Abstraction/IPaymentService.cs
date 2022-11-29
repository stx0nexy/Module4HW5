using Module4HW5.Models;

namespace Module4HW5.Services.Abstraction;

public interface IPaymentService
{
    Task<int> SavePaymentAsync(Payment payment);
    Task<int> UpdatePaymentAsync(Payment payment);
    Task<Payment> GetPaymentAsync(int id);
    Task<bool> DeletePaymentAsync(int id);
    Task<IReadOnlyList<Payment>> GetOrdersByPaymentType(string paymentType);
}