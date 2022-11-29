using Module4HW5.Data.Entities;
using Module4HW5.Models;

namespace Module4HW5.Repositories.Abstruction;

public interface IPaymentRepository
{
    Task<int> CreatePaymentAsync(Payment payment);
    Task<PaymentEntity?> UpdatePaymentAsync(PaymentEntity payment);
    Task<PaymentEntity?>ReadPaymentAsync(int id);
    Task<bool> DeletePaymentAsync(int id);
    Task<IEnumerable<PaymentEntity>> GetOrdersByPaymentType(string paymentType);
}