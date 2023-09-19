using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Attendance
    {
        public Guid Id { get; set; }
        public Guid? InternWorkShiftId { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }

        public virtual InternWorkShift? InternWorkShift { get; set; }
    }
}
