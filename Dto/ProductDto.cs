using AB_Api.Models;

namespace AB_Api.Dto
{
    public class ProductDto
    {


        public int IdProduct { get; set; }

        public string Title { get; set; }
        public int CategoriesNum { get; set; }
        public int UnitsNum { get; set; }
        public string? Code { get; set; }
        public DateTime? CrDate  { get; set; }
        /*
          public string? Detials { get; set; }
          public int? QtyAvaliabe { get; set; }
          public decimal? PriceBuy { get; set; }
          public decimal? PriceSale { get; set; }

          public bool? IsAvaliable { get; set; }
        */
    }
}
