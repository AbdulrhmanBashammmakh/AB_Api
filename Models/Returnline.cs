using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Returnline
    {
        public int IdProduct { get; set; }
        public int IdReturn { get; set; }
        public int? QtyReturn { get; set; }
        public decimal? Price { get; set; }
        public decimal? SubtotalReturn { get; set; }

        public virtual ReturnSale IdReturnNavigation { get; set; } = null!;
    }
}
