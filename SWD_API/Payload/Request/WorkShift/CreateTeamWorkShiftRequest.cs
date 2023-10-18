namespace SWD_API.Payload.Request.WorkShift
{
    public class CreateTeamWorkShiftRequest
    {  public Guid TeamLeaderID { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }         
        public Guid? ProjectId { get; set; }
    }
}
