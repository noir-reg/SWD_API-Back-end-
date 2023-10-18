namespace SWD_API.Payload.Request.WorkShift
{
    public class CreateInternWorkShiftRequest
    {
        public Guid? WorkShiftId { get; set; }
        public Guid? InternId { get; set; }        
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
