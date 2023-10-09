using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public interface IAttendanceRepo
    {
        List<AttendanceModel> GetAll();
        Task<List<AttendanceModel>> GetInternAttendances(Guid id);
        
    }
}
