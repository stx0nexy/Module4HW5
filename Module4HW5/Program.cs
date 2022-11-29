using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module4HW5;
using Module4HW5.Config;
using Module4HW5.Data;
using Module4HW5.Repositories;
using Module4HW5.Repositories.Abstruction;
using Module4HW5.Services;
using Module4HW5.Services.Abstraction;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
        => opts.UseNpgsql(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>()
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<IProductRepository, ProductRepository>()
        .AddTransient<ICustomersRepository, CustomersRepository>()
        .AddTransient<IOrderDetailsRepository, OrderDetailsRepository>()
        .AddTransient<IOrdersRepository, OrdersRepository>()
        .AddTransient<IPaymentRepository, PaymentRepository>()
        .AddTransient<IShipperRepository, ShipperRepository>()
        .AddTransient<ISuppliersRepository, SuppliersRepository>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<IProductService, ProductService>()
        .AddTransient<ICustomersService, CustomersService>()
        .AddTransient<IOrderDetailsServices, OrderDetailsServices>()
        .AddTransient<IOrdersService, OrdersService>()
        .AddTransient<IPaymentService, PaymentService>()
        .AddTransient<IShipperService, ShipperService>()
        .AddTransient<ISuppliersService, SuppliersService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
await app!.Start();