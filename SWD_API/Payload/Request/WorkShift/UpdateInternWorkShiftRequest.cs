namespace SWD_API.Payload.Request.WorkShift
{
    public class UpdateInternWorkShiftRequest
    {
        public Guid Id { get; set; }
        public string? WorkShiftId { get; set; }
        public string? InternId { get; set; }        
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
    }
}
