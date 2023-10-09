namespace SWD_API.Payload.Response.Project
{
    public class GetInternProjectResponse
    {
        public Guid Id { get; set; }
        public Guid? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
