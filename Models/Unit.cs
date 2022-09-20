using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Unit1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
