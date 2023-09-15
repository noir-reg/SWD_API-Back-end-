using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? Role { get; set; }
    }
}
