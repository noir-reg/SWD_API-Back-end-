using Microsoft.EntityFrameworkCore;
using SWD_API.Payload.Request.Attendance;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class AttendanceRepo : IAttendanceRepo
    {
        public readonly SWDProjectContext _context = new();

      

        public async Task<bool> CreateAttendance(CreateAttendanceRequest createAttendanceRequest)
        {
            await _context.AddAsync(new Attendance
            {
                Id=Guid.NewGuid(),
                InterId=createAttendanceRequest.InterId,
                CheckIn=createAttendanceRequest.CheckIn,
                CheckOut=createAttendanceRequest.CheckOut,
                Description=createAttendanceRequest.Description,    
                Status=createAttendanceRequest.Status,
                UpdateTime=DateTime.UtcNow
            });
            var result=await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }

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

        public async Task<bool> UpdateAttendanceStatus(Guid id,string status)
        {
           var att=await _context.Attendances.Where(x=>x.Id==id).FirstOrDefaultAsync();
            if(att==null)
                return false;
            att.Status = Int32.Parse(status);
            var result= await _context.SaveChangesAsync();
            if(result>0)
                return true;

            return false;
        }
    }
}
