﻿namespace SWD_API.Payload.Response.Account
{
    public class GetAccountResponse
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? InternshipSemester { get; set; }
        public string? Team { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Status { get; set; }
    }
}
