using Microsoft.Extensions.Logging;
using Module4HW5.Data;
using Module4HW5.Data.Entities;
using Module4HW5.Models;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services.Abstraction;

namespace Module4HW5.Services;

public class CustomersService :BaseDataService<ApplicationDbContext>, ICustomersService
{
    private readonly ICustomersRepository _customersRepository;
    private readonly ILogger<CustomersService> _loggerService;
    
    public CustomersService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICustomersRepository customersRepository,
        ILogger<CustomersService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _customersRepository = customersRepository;
        _loggerService = loggerService;
    }
    
    public async Task<int> SaveCustomerAsync(Customer customer)
    {
        await _customersRepository.CreateCustomerAsync(customer);
        _loggerService.LogInformation($"Created customer with Id = {customer.CustomerID}");
        return customer.CustomerID;
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        var result = await _customersRepository.ReadCustomerAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded customers");
            return null!;
        }

        return new Customer()
        {
            CustomerID = result.CustomerID,
            FirstName = result.FirstName,
            LastName = result.LastName
        };
    }

    public async Task<int> UpdateCustomerAsync(Customer customer)
    {
        var result = new CustomersEntity()
        {
            CustomerID = customer.CustomerID,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };
        await _customersRepository.UpdateCustomerAsync(result);
        _loggerService.LogInformation($"Modified customer with Id = {result.CustomerID}");
        return result.CustomerID;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        await _customersRepository.DeleteCustomerAsync(id);
        _loggerService.LogInformation($"Delete customer with Id = {id}");
        return true;
    }

    public async Task<IReadOnlyList<Customer>?> GetOrdersFromCustomersMoreThan4()
    {
        var result = await _customersRepository.GetOrdersFromCustomersMoreThan4();
        if (result == null)
        {
            _loggerService.LogWarning($"Not founded orders ");
            return null!;
        }

        return result.Select(r => new Customer()
        {
            CustomerID = r.CustomerID,
            FirstName = r.FirstName,
            LastName = r.LastName,
            Orders = r.OrdersEntities.Select(s => new Order()
            {
                OrderID = s.OrderID,
                CustomerID = s.CustomerID,
                PaymentID = s.PaymentID,
                ShipperID = s.ShipperID,
                OrderNumber = s.OrderNumber,
                Payments = new Payment()
                {
                    PaymentID = s.PaymentEntity.PaymentID,
                    PaymentType = s.PaymentEntity.PaymentType
                }
            })
        }).ToList();
    }
}