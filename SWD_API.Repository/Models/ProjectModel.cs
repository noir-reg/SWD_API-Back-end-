using SWD_API.Repository.Models;

namespace SWD_API.Models
{
    public partial class ProjectModel
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
