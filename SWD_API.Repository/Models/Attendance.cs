using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Attendance
    {
        public Guid Id { get; set; }
        public Guid? InterId { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public virtual Intern? Inter { get; set; }
    }
}
