using AB_Api.Models;

namespace AB_Api.ViewModels
{
    public class ProductViewModel
    {


        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public string? Detials { get; set; }
        public int? QtyAvaliabe { get; set; }
        public decimal? PriceBuy { get; set; }
        public decimal? PriceSale { get; set; }
        public int UnitId { get; set; }

        public List<Unit> Units { get; set; }

        public int CateId { get; set; }
        public List<Category> Categories { get; set; }

      


    }
}
