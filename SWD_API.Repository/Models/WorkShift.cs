using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class WorkShift
    {
        public WorkShift()
        {
            InternWorkShifts = new HashSet<InternWorkShift>();
        }

        public Guid Id { get; set; }
        public Guid? TeamId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? ProjectId { get; set; }

        public virtual Project? Project { get; set; }
        public virtual Team? Team { get; set; }
        public virtual ICollection<InternWorkShift> InternWorkShifts { get; set; }
    }
}
