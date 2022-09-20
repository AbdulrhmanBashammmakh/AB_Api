using AB_Api.Models;

namespace AB_Api.ViewModels
{
    public class ProductOrderLine
    {
              private readonly Orderline orderline;
          
             private readonly Product product;
        public ProductOrderLine(Orderline orderline,Product product)
        {
            this.orderline = orderline;
            this.product = product;
        }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }

        
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Subtotal { get; set; }


    }
}
