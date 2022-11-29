using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class PaymentService :BaseDataService<ApplicationDbContext>, IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger<PaymentService> _loggerService;
    
    public PaymentService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IPaymentRepository paymentRepository,
        ILogger<PaymentService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _paymentRepository = paymentRepository;
        _loggerService = loggerService;
    }
    
    public async Task<int> SavePaymentAsync(Payment payment)
    {
        await _paymentRepository.CreatePaymentAsync(payment);
        _loggerService.LogInformation($"Created payment with Id = {payment.PaymentID}");
        return payment.PaymentID;
    }

    public async Task<Payment> GetPaymentAsync(int id)
    {
        var result = await _paymentRepository.ReadPaymentAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded payments");
            return null!;
        }

        return new Payment()
        {
            PaymentID = result.PaymentID,
            PaymentType = result.PaymentType
        };
    }

    public async Task<int> UpdatePaymentAsync(Payment payment)
    {
        var result = new PaymentEntity()
        {
            PaymentID = payment.PaymentID,
            PaymentType = payment.PaymentType
        };
        await _paymentRepository.UpdatePaymentAsync(result);
        _loggerService.LogInformation($"Modified payment with Id = {result.PaymentID}");
        return result.PaymentID;
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        await _paymentRepository.DeletePaymentAsync(id);
        _loggerService.LogInformation($"Delete payment with Id = {id}");
        return true;
    }

    public async Task<IReadOnlyList<Payment>> GetOrdersByPaymentType(string paymentType)
    {
        var result = await _paymentRepository.GetOrdersByPaymentType(paymentType);
        if (result == null)
        {
            _loggerService.LogWarning($"Not founded orders by payment type = {paymentType} ");
            return null!;
        }

        return result.Select(r => new Payment()
        {
            PaymentID = r.PaymentID,
            PaymentType = r.PaymentType,
            Orders = r.OrdersEntities.Select(e => new Order()
            {
                OrderID = e.OrderID,
                CustomerID = e.CustomerID,
                PaymentID = e.PaymentID,
                ShipperID = e.ShipperID,
                OrderNumber = e.OrderNumber
            })
        }).ToList();
    }
}