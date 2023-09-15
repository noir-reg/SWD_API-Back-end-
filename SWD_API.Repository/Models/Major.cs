using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Major
    {
        public Major()
        {
            Interns = new HashSet<Intern>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Intern> Interns { get; set; }
    }
}
