using PetService.Business;
using PetService.Data.Models;

namespace ConsoleTest


{
    internal class Program
    {
       

        static async Task Main(string[] args)
        {
        var paymentBusiness = new PaymentBusiness();
        var PaymentResults = await paymentBusiness.GetAll();

        var payment = (IEnumerable<Payment>) PaymentResults.Data;
        Console.WriteLine("Danh sach");
        foreach(var payments in payment)
        {
            Console.WriteLine($"PaymentId: { payments.PaymentId} ");
        }
        
        }
    }
}


