using Microsoft.EntityFrameworkCore;
using SWD_API.Payload.Response.InternWorkShift;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class WorkShiftRepo : IWorkShiftRepo
    {
        private readonly SWDProjectContext _context = new();
        public List<WorkShiftModel> GetAll()
        {
            //throw new NotImplementedException();
            var workshift = _context.WorkShifts.Select(ws =>
                    new WorkShiftModel
                    {
                        Id = ws.Id,
                        TeamId = ws.TeamId,
                        StartTime = ws.StartTime,
                        EndTime = ws.EndTime,
                        Date = ws.Date,
                        Description = ws.Description,
                        UpdateTime = ws.UpdateTime,
                        ProjectId = ws.ProjectId

                    });
            return workshift.ToList();
        }

        public async Task<WorkShiftModel> GetById(Guid id)
        {
            var workShift= await _context.WorkShifts.Where(x=>x.Id.Equals(id)).Select(ws =>
                    new WorkShiftModel
                    {
                        Id = ws.Id,
                        TeamId = ws.TeamId,
                        StartTime = ws.StartTime,
                        EndTime = ws.EndTime,
                        Date = ws.Date,
                        Description = ws.Description,
                        UpdateTime = ws.UpdateTime,
                        ProjectId = ws.ProjectId

                    }).FirstOrDefaultAsync();
            return workShift;
        }

        public async Task<List<GetInternWorkShiftResponse>> GetInternWorkShifts(Guid id)
        {
            var list = await _context.InternWorkShifts.Where(x => x.InternId == id).Select(x => new GetInternWorkShiftResponse
            {
                Id = x.Id,
                WorkShiftId = x.WorkShiftId,
                UpdateTime = x.UpdateTime,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut

            }).ToListAsync();
            return list;
        }
    }
}
