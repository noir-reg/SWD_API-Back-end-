using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class University
    {
        public University()
        {
            Interns = new HashSet<Intern>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Intern> Interns { get; set; }
    }
}
