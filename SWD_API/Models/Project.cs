using System;
using System.Collections.Generic;

namespace SWD_API.Models
{
    public partial class Project
    {
        public Project()
        {
            InternProjectMappings = new HashSet<InternProjectMapping>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<InternProjectMapping> InternProjectMappings { get; set; }
    }
}
