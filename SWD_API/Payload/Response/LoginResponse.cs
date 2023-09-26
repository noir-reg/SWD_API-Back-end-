using Microsoft.Win32.SafeHandles;
using SWD_API.Repository.Models;

namespace SWD_API.Payload.Response;

public class LoginResponse
{
    public LoginResponse()
    {
        Attendances = new HashSet<Attendance>();
        InternProjectMappings = new HashSet<InternProjectMapping>();
        InternWorkShifts = new HashSet<InternWorkShift>();
    }
    public  string AccessToken {  get; set; }
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
    
    public virtual ICollection<Attendance> Attendances { get; set; }
    public virtual ICollection<InternProjectMapping> InternProjectMappings { get; set; }
    public virtual ICollection<InternWorkShift> InternWorkShifts { get; set; }
}
