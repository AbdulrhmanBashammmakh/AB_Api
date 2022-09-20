using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class CurrentProduct
    {
        public int IdProduct { get; set; }
        public string? Detials { get; set; }
        public int? QtyAvaliabe { get; set; }
        public decimal? PriceBuy { get; set; }
        public decimal? PriceSale { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
