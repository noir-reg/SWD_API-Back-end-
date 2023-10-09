namespace SWD_API.Payload.Response.InternWorkShift
{
    public class GetInternWorkShiftResponse
    {
        public Guid Id { get; set; }
        public Guid? WorkShiftId { get; set; }       
        public DateTime? UpdateTime { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
