using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Invoice
    {
        public int IdInvoice { get; set; }
        public decimal? Total { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Net { get; set; }
        public string? Payment { get; set; }
        public int? IdCust { get; set; }

        public virtual Customer? IdCustNavigation { get; set; }
    }
}
