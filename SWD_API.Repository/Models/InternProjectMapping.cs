using System;
using System.Collections.Generic;

namespace SWD_API.Repository.Models
{
    public partial class InternProjectMapping
    {
        public Guid Id { get; set; }
        public Guid? InternId { get; set; }
        public Guid? ProjectId { get; set; }

        public virtual Intern? Intern { get; set; }
        public virtual Project? Project { get; set; }
    }
}
