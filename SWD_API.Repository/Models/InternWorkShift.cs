using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class InternWorkShift
    {
        public Guid Id { get; set; }
        public Guid? WorkShiftId { get; set; }
        public Guid? InternId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public virtual Intern? Intern { get; set; }
        public virtual WorkShift? WorkShift { get; set; }
    }
}
