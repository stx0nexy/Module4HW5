using Module4HW5.Models;

namespace Module4HW5;

public class InitialValues
{
    public static Category category1 = new Category()
    {
        CategoryID = 1,
        CategoryName = "category1"
    };
    public static Category category2 = new Category()
    {
        CategoryID = 2,
        CategoryName = "category2"
    };
    public static Customer customer1 = new Customer()
    {
        CustomerID = 1,
        FirstName = "FirstNameCustomer1",
        LastName = "LastNameCustomer1"
    };
    public static Customer customer2 = new Customer()
    {
        CustomerID = 2,
        FirstName = "FirstNameCustomer2",
        LastName = "LastNameCustomer2"
    };

    public static Payment payment1 = new Payment()
    {
        PaymentID = 1,
        PaymentType = "cash"
    };
    public static Payment payment2 = new Payment()
    {
        PaymentID = 2,
        PaymentType = "card"
    };

    public static Shipper shipper1 = new Shipper()
    {
        ShipperID = 1,
        CompanyName = "Company1"
    };
    public static Shipper shipper2 = new Shipper()
    {
        ShipperID = 2,
        CompanyName = "Company2"
    };

    public static Supplier supplier1 = new Supplier()
    {
        SupplierID = 1,
        ContactFName = "FName1",
        ContactLName = "lName1"
    };
    public static Supplier supplier2 = new Supplier()
    {
        SupplierID = 2,
        ContactFName = "FName2",
        ContactLName = "lName2"
    };
}