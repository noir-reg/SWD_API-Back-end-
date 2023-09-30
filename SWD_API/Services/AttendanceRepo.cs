using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class AttendanceRepo : IAttendanceRepo
    {
        public readonly SWDProjectContext _context = new();
        public List<AttendanceModel> GetAll()
        {
            //throw new NotImplementedException();
            var attendance = _context.Attendances.Select(atd =>
                    new AttendanceModel
                    {
                        Id = atd.Id,
                        InterId = atd.InterId,
                        Status = atd.Status,
                        Description = atd.Description,
                        UpdateTime = atd.UpdateTime,
                        CheckIn = atd.CheckIn,
                        CheckOut = atd.CheckOut
                    });
            return attendance.ToList();
        }
    }
}
