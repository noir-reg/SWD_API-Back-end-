using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class InternshipSemester
    {
        public InternshipSemester()
        {
            Interns = new HashSet<Intern>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Intern> Interns { get; set; }
    }
}
