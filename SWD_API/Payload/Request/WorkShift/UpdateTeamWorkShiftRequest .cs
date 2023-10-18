namespace SWD_API.Payload.Request.WorkShift
{
    public class UpdateTeamWorkShiftRequest
    {
        public Guid Id { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        
        public string? ProjectId { get; set; }
    }
}
