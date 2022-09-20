using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Cate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
