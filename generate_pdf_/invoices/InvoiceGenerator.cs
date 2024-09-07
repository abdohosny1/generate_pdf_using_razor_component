using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generate_pdf_.invoices
{
    internal class InvoiceGenerator
    {

        public static Invoice Generate()
        {
            var faker = new Faker();
             return new  Invoice{
                 Number=faker.Random.Number(1000,999).ToString(),
                 IssueDate=faker.Date.SoonDateOnly(0),
                 DueDate=faker.Date.SoonDateOnly(0).AddMonths(1),
                 SellerAddress = new Address
                 {
                        CompanyName = "Dometrain",
                        City = "London",
                        Email = "nick@dometrain.com",
                        Phone = faker.Phone.PhoneNumber(),
                        Street = "Super London",
                        State = "LD",
                        Zipcode = "69420"
                 },
                 CustomerAddress = new Address
                 {
                     CompanyName = faker.Company.CompanyName(),
                     City = faker.Address.City(),
                     Email = faker.Person.Email,
                     Phone = faker.Phone.PhoneNumber(),
                     Street = faker.Address.StreetAddress(),
                     State = faker.Address.State(),
                     Zipcode = faker.Address.ZipCode()
                 },
                 Items=new List<OrderItem>
                 {
                     new()
                     {
                         Name="getting started",
                         Price=79.23m,
                         Quentity=2
                     },
                      new()
                     {
                         Name="from zero to hero",
                         Price=79.23m,
                         Quentity=2
                     },
                       new()
                     {
                         Name="getting started",
                         Price=79.23m,
                         Quentity=2
                     }
                 }
             };
        }

        // Calculate total price
    }
}
