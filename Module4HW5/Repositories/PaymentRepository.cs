using Microsoft.EntityFrameworkCore;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Repositories;

public class PaymentRepository :IPaymentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }
    
    public async Task<int> CreatePaymentAsync(Payment payment)
    {
        var result = await _dbContext.Payments.AddAsync(new PaymentEntity()
        {
            PaymentID = payment.PaymentID,
            PaymentType = payment.PaymentType
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.PaymentID;
    }
    public async Task<PaymentEntity> UpdatePaymentAsync(PaymentEntity payment)
    {
        if (payment.PaymentID != default)
        {
            _dbContext.Entry(payment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return (payment);
    }
    public async Task<PaymentEntity?> ReadPaymentAsync(int id)
    { 
        return await _dbContext.Payments.FirstOrDefaultAsync(f => f.PaymentID == id);
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        PaymentEntity payment = await _dbContext.Payments.FirstAsync(c => c.PaymentID == id);
        _dbContext.Payments.Remove(payment);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<PaymentEntity>> GetOrdersByPaymentType(string paymentType)
    {
        return await _dbContext.Payments.Where(s => s.PaymentType == paymentType)
            .Include(e => e.OrdersEntities).ToListAsync();
    }
}