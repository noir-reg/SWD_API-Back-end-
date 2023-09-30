using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_API.Repository.Models
{
    public partial class WorkShiftModel
    {
        public Guid Id { get; set; }
        public Guid? TeamId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
