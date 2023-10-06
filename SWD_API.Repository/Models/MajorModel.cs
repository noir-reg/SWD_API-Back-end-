using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_API.Repository.Models
{
    public partial class MajorModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Status { get; set; }
    }
}
