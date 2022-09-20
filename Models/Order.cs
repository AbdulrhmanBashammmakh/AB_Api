using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderlines = new HashSet<Orderline>();
        }

        public int Id { get; set; }
        public int? CustId { get; set; }
        public DateTime? CrDate { get; set; }

        public virtual Customer? Cust { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
    }
}
