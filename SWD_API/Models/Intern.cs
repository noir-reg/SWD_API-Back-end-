using System;
using System.Collections.Generic;

namespace SWD_API.Models
{
    public partial class Intern
    {
        public Intern()
        {
            InternProjectMappings = new HashSet<InternProjectMapping>();
            InternWorkShifts = new HashSet<InternWorkShift>();
        }

        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public Guid? UniversityId { get; set; }
        public Guid? MajorId { get; set; }
        public Guid? InternshipSemesterId { get; set; }
        public Guid? TeamId { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual InternshipSemester? InternshipSemester { get; set; }
        public virtual Major? Major { get; set; }
        public virtual Team? Team { get; set; }
        public virtual University? University { get; set; }
        public virtual ICollection<InternProjectMapping> InternProjectMappings { get; set; }
        public virtual ICollection<InternWorkShift> InternWorkShifts { get; set; }
    }
}
