namespace SWD_API.Payload.Request.Attendance
{
    public class CreateAttendanceRequest
    {
        public Guid? InterId { get; set; }
        public int? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
