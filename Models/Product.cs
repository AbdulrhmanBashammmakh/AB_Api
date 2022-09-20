using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Product
    {

        private DateTime _created ;

        
        public Product()
        {
            Orderlines = new HashSet<Orderline>();
        }
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? UnitId { get; set; }
        public int? CateId { get; set; }
        public string? Code { get; set; }
        public DateTime? CrDate
        {
            get { return _created; }
            set => _created = DateTime.Now;
        }
      
        public virtual Category? Cate { get; set; }
        public virtual Unit? Unit { get; set; }
       public virtual ICollection<Orderline> Orderlines { get; set; }
      
    }
}
