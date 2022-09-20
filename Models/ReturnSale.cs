using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class ReturnSale
    {
        public ReturnSale()
        {
            Returnlines = new HashSet<Returnline>();
        }

        public int Id { get; set; }
        public int IdOrder { get; set; }
        public DateTime? CrDate { get; set; }

        public virtual ICollection<Returnline> Returnlines { get; set; }
    }
}
