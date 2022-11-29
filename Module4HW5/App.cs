using Module4HW5.Models;
using Module4HW5.Services.Abstraction;

namespace Module4HW5;

public class App
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly ICustomersService _customersService;
    private readonly IOrderDetailsServices _orderDetailsServices;
    private readonly IOrdersService _ordersService;
    private readonly IPaymentService _paymentService;
    private readonly IShipperService _shipperService;
    private readonly ISuppliersService _suppliersService;

        public App( ICategoryService categoryService, IProductService productService,
        ICustomersService customersService, IOrdersService ordersService,
        IPaymentService paymentService, IOrderDetailsServices orderDetailsServices,
        IShipperService shipperService, ISuppliersService suppliersService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _customersService = customersService;
        _ordersService = ordersService;
        _orderDetailsServices = orderDetailsServices;
        _paymentService = paymentService;
        _shipperService = shipperService;
        _suppliersService = suppliersService;
    }

    public async Task Start()
    {
        var nameProduct1 = "product1";
        var nameProduct2 = "product2";
        await _categoryService.SaveCategoryAsync(InitialValues.category1);
        await _customersService.SaveCustomerAsync(InitialValues.customer1);
        await _shipperService.SaveShipperAsync(InitialValues.shipper1);
        await _shipperService.SaveShipperAsync(InitialValues.shipper2);
        await _paymentService.SavePaymentAsync(InitialValues.payment1);
        await _paymentService.SavePaymentAsync(InitialValues.payment2);
        await _suppliersService.SaveSupplierAsync(InitialValues.supplier1);
        var product1 =await _productService.SaveProductAsync(1,
            nameProduct1,InitialValues.category1.CategoryID, InitialValues.supplier1.SupplierID);
        var product2 =await _productService.SaveProductAsync(2,
            nameProduct2,InitialValues.category1.CategoryID,InitialValues.supplier1.SupplierID);
        var order1 =await _ordersService.SaveOrderAsync(1, 1,
            InitialValues.customer1.CustomerID,
            InitialValues.payment1.PaymentID, InitialValues.shipper1.ShipperID);
        var order2 =await _ordersService.SaveOrderAsync(2, 2,
            InitialValues.customer1.CustomerID,
            InitialValues.payment1.PaymentID, InitialValues.shipper1.ShipperID);
        var order3 =await _ordersService.SaveOrderAsync(3, 3,
            InitialValues.customer1.CustomerID,
            InitialValues.payment2.PaymentID, InitialValues.shipper1.ShipperID);
        var order4 =await _ordersService.SaveOrderAsync(4, 4,
            InitialValues.customer1.CustomerID,
            InitialValues.payment2.PaymentID, InitialValues.shipper1.ShipperID);
        var order5 =await _ordersService.SaveOrderAsync(5, 5,
            InitialValues.customer1.CustomerID,
            InitialValues.payment1.PaymentID, InitialValues.shipper1.ShipperID);
        var orderDetail1 =await _orderDetailsServices.SaveOrderDetailAsync(1,
            product1.ProductID, order1.OrderID);
        var getOrder1 =await _ordersService.GetOrderAsync(order1.OrderID);
        var getOrdersMore4 = await _customersService.GetOrdersFromCustomersMoreThan4();
        var getOrdersFromCustomer = await _ordersService.GetOrdersFromCustomer(InitialValues.customer1.CustomerID);
        var getOrdersByPaymentType = await _paymentService.GetOrdersByPaymentType(InitialValues.payment1.PaymentType);
        var getProductsByCategoryID = await _productService.GetProductsByCategoryID(InitialValues.category1.CategoryID);
        var getOrdersByShipperId = await _shipperService.GetOrdersByShipperId(InitialValues.shipper1.ShipperID);
        var clearAllProductsInCertainSupplier = await _suppliersService.ClearAllProductsInCertainSupplier(InitialValues.supplier1.SupplierID);
        await _orderDetailsServices.DeleteOrderDetailAsync(orderDetail1.OrderDetailID);
        await _ordersService.DeleteOrderAsync(order1.OrderID);
        await _ordersService.DeleteOrderAsync(order2.OrderID);
        await _ordersService.DeleteOrderAsync(order3.OrderID);
        await _ordersService.DeleteOrderAsync(order4.OrderID);
        await _ordersService.DeleteOrderAsync(order5.OrderID);
        await _productService.DeleteProductAsync(product1.ProductID);
        await _productService.DeleteProductAsync(product2.ProductID);
        await _categoryService.DeleteCategoryAsync(InitialValues.category1.CategoryID);
        await _customersService.DeleteCustomerAsync(InitialValues.customer1.CustomerID);
        await _shipperService.DeleteShipperAsync(InitialValues.shipper1.ShipperID);
        await _shipperService.DeleteShipperAsync(InitialValues.shipper2.ShipperID);
        await _paymentService.DeletePaymentAsync(InitialValues.payment1.PaymentID);
        await _paymentService.DeletePaymentAsync(InitialValues.payment2.PaymentID);
        await _suppliersService.DeleteSupplierAsync(InitialValues.supplier1.SupplierID);
    }
}
