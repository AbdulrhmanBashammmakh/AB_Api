using AB_Api.Models;

namespace AB_Api.ViewModels
{
    public class ProductViewModel
    {
        private readonly Product _product;
        private readonly Unit un;
        private readonly Category ca;


        public ProductViewModel(Product product, Unit _un, Category _ca)
        {
            _product = product;
        ca = _ca;
            un = _un;
        }
     
        public int ProductId  { get; set; }

    public string? Title { get; set; }
        public string? Code { get; set; }
        public string? Detials { get; set; }
        public int? QtyAvaliabe { get; set; }
        public decimal? PriceBuy { get; set; }
        public decimal? PriceSale { get; set; }
        public int UnitId { get; set; }


        public int CateId { get; set; }
       
        public virtual Category? Categorieslist { get; set; }
        public virtual Unit? Unitslist { get; set; }



    }
}
