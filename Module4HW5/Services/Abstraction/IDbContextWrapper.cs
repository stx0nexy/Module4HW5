using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Module4HW5.Services.Abstraction;

public interface IDbContextWrapper<T>
    where T : DbContext
{
    T DbContext { get; }
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}