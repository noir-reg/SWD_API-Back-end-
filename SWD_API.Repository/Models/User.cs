﻿using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class User
    {
        public User()
        {
            Teams = new HashSet<Team>();
        }

        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
