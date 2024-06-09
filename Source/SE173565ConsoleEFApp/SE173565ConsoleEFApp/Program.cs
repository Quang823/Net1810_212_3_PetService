// See https://aka.ms/new-console-template for more information
using SE173565ConsoleEFApp.Models;

Console.WriteLine("Hello, World!");

var _context = new Net1810_212_3_PetServiceContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Net1810_212_3_PetServiceContext>());


Console.WriteLine("1. select * from Payment");
var payments = _context.Payments.ToArray();
foreach (var payment in payments)
{
    Console.WriteLine(payment.PaymentId);
    Console.WriteLine(payment.AppointmentId);
    Console.WriteLine(payment.TotalPrice);
}

/*Console.WriteLine("2. select * from Customer where CustomerID = '1'");
var item = _context.Customers.FirstOrDefault(c => c.CustomerId == 1);
//FirstOrDefault: lay phan tu dau tien hoac mac dinh
//c: dat chu gi cung dc
if (item != null)
{
    Console.WriteLine(item.Name);
}

Console.WriteLine("3. insert into Customer(");*/