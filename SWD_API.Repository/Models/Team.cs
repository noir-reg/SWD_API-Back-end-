using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Team
    {
        public Team()
        {
            Interns = new HashSet<Intern>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? QuantityOfMember { get; set; }
        public Guid? TeamLeaderId { get; set; }

        public virtual TeamLeader? TeamLeader { get; set; }
        public virtual ICollection<Intern> Interns { get; set; }
    }
}
