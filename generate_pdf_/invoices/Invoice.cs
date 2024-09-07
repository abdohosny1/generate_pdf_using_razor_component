using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generate_pdf_.invoices
{
    public class Invoice
    {
        public string Number { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DueDate { get; set; }
        public Address SellerAddress { get; set; }
        public Address CustomerAddress { get; set; }
        public List<OrderItem> Items { get; set; }

        public string Comment { get; set; }
    }


    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quentity { get; set; }

    }
    public class Address
    {
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public object Email { get; set; }
        public string Phone { get; set; }


    }
}
