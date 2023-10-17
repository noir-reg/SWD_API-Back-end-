namespace SWD_API.Data
{
    public class InternshipSemesterData
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
