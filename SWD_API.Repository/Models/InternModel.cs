using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_API.Repository.Models
{
    public partial class InternModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public Guid? UniversityId { get; set; }
        public Guid? MajorId { get; set; }
        public Guid? InternshipSemesterId { get; set; }
        public Guid? TeamId { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Status { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
