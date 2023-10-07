namespace SWD_API.Payload.Request.Account
{
    public class UpdateInternInforRequest
    {    public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? UniversityId { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MajorId { get; set; }
        public UpdateInternInforRequest() { }
    }
}
