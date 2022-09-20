using System;
using System.Collections.Generic;

namespace AB_Api.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? IsAdmin { get; set; }
    }
}
