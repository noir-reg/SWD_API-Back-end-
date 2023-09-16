using System;
using System.Collections.Generic;

namespace SWD_API.Models
{
    public partial class InternWorkShift
    {
        public InternWorkShift()
        {
            Attendances = new HashSet<Attendance>();
        }

        public Guid Id { get; set; }
        public Guid? WorkShiftId { get; set; }
        public Guid? InternId { get; set; }

        public virtual Intern? Intern { get; set; }
        public virtual WorkShift? WorkShift { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
