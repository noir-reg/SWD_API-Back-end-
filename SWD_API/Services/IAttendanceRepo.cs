using SWD_API.Payload.Request.Attendance;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IAttendanceRepo
    {
        List<AttendanceModel> GetAll();
        Task<List<AttendanceModel>> GetInternAttendances(Guid id);
        Task<bool> CreateAttendance(CreateAttendanceRequest createAttendanceRequest);
        Task<bool> UpdateAttendanceStatus(Guid id,string status);
        
    }
}
