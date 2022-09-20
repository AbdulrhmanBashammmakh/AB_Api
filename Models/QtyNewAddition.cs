using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class QtyNewAddition
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int QtyAdd { get; set; }
        public string? Note { get; set; }
        public DateTime? CrDate { get; set; }
    }
}
