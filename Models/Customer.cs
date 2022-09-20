using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? NameCust { get; set; }
        public string? PhoneCust { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
