using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AttendanceModel>> GetInternAttendances(Guid id)
        {
            var list = await _context.Attendances.Where(x => x.InterId.Equals(id)).Select(atd =>
                     new AttendanceModel
                     {
                         Id = atd.Id,
                         InterId = atd.InterId,
                         Status = atd.Status,
                         Description = atd.Description,
                         UpdateTime = atd.UpdateTime,
                         CheckIn = atd.CheckIn,
                         CheckOut = atd.CheckOut
                     }).ToListAsync();
            return list;
        }
    }
}
