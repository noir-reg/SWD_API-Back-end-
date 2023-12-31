﻿using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class Team
    {
        public Team()
        {
            Interns = new HashSet<Intern>();
            WorkShifts = new HashSet<WorkShift>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? QuantityOfMember { get; set; }
        public Guid? TeamLeaderId { get; set; }
        public string? Code { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual User? TeamLeader { get; set; }
        public virtual ICollection<Intern> Interns { get; set; }
        public virtual ICollection<WorkShift> WorkShifts { get; set; }
    }
}
