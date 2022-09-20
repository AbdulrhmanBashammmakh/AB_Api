using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Orderline
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Subtotal { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
