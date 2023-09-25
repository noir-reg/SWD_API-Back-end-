using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Project
    {
        public Project()
        {
            InternProjectMappings = new HashSet<InternProjectMapping>();
            WorkShifts = new HashSet<WorkShift>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual ICollection<InternProjectMapping> InternProjectMappings { get; set; }
        public virtual ICollection<WorkShift> WorkShifts { get; set; }
    }
}
