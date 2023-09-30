using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_API.Repository.Models
{
    public partial class AttendanceModel
    {
        public Guid Id { get; set; }
        public Guid? InterId { get; set; }
        public int? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
