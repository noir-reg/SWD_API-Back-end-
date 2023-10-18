using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWD_API.Payload.Request.WorkShift;
using SWD_API.Payload.Response.InternWorkShift;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class WorkShiftRepo : IWorkShiftRepo
    {
        private readonly SWDProjectContext _context = new();

        public async Task<bool> CreateInternWorkShift(Guid workShiftId, Guid internId, DateTime checkIn, DateTime checkOut)
        {
            var add = await _context.AddAsync(new InternWorkShift
            {
                Id = Guid.NewGuid(),
                CheckIn = checkIn,
                CheckOut = checkOut,
                InternId = internId,
                WorkShiftId = workShiftId,
                UpdateTime = DateTime.UtcNow
            });
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;

        }

        public async Task<bool> CreateTeamWorkShift(CreateTeamWorkShiftRequest createTeamWorkShiftRequest)
        {
            var teamId = await _context.Teams.Where(x => x.TeamLeaderId == createTeamWorkShiftRequest.TeamLeaderID).Select(x => x.Id).FirstOrDefaultAsync();
            if (teamId.ToString().IsNullOrEmpty())
                return false;
            var workShift = new WorkShift
            {
                Id = Guid.NewGuid(),
                TeamId = teamId,
                StartTime = createTeamWorkShiftRequest.StartTime,
                EndTime = createTeamWorkShiftRequest.EndTime,
                Date = createTeamWorkShiftRequest.Date,
                Description = createTeamWorkShiftRequest.Description,
                UpdateTime = DateTime.UtcNow,
                ProjectId = createTeamWorkShiftRequest.ProjectId
            };
            var add = await _context.AddAsync(workShift);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;

        }

        public async Task<bool> DeleteInternWorkShift(Guid id)
        {
            var iws = await _context.InternWorkShifts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (iws != null)
            {
                _context.InternWorkShifts.Remove(iws);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }

            return false;
        }

        public async Task<bool> DeleteTeamWorkShift(Guid id)
        {
            var internWorkShift = await _context.InternWorkShifts.Where(x => x.WorkShiftId == id).FirstOrDefaultAsync();
            if (internWorkShift != null)
            {
                return false;
            }
            var ws = await _context.WorkShifts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ws != null)
            {
                _context.WorkShifts.Remove(ws);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }

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
            var workShift = await _context.WorkShifts.Where(x => x.Id.Equals(id)).Select(ws =>
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
            var list = await _context.InternWorkShifts.Where(x => x.InternId == id).Include(x => x.WorkShift).Select(x => new GetInternWorkShiftResponse
            {
                Id = x.Id,
                WorkShiftId = x.WorkShiftId,
                UpdateTime = x.UpdateTime,
                WorkingDate = x.WorkShift == null ? null : x.WorkShift.Date,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut

            }).ToListAsync();
            return list;
        }

        public Task<List<WorkShiftModel>> GetTeamWorkShifts(Guid teamLeaderId)
        {
            var teamID = _context.Teams.Where(x => x.TeamLeaderId == teamLeaderId).Select(x => x.Id).FirstOrDefault();
            var workShifts = _context.WorkShifts.Where(x => x.TeamId == teamID).Select(x => new WorkShiftModel
            {
                Id = x.Id,
                TeamId = x.TeamId,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Date = x.Date,
                Description = x.Description,
                UpdateTime = x.UpdateTime,
                ProjectId = x.ProjectId
            }).ToListAsync();
            return workShifts;
        }

        public async Task<bool> UpdateInternWorkShift(UpdateInternWorkShiftRequest updateInternWorkShiftRequest)
        {
            var iws = await _context.InternWorkShifts.Where(x => x.Id == updateInternWorkShiftRequest.Id).FirstOrDefaultAsync();
            if (iws != null)
            {
                iws.WorkShiftId = updateInternWorkShiftRequest.WorkShiftId.IsNullOrEmpty() ? iws.WorkShiftId : Guid.Parse(updateInternWorkShiftRequest.WorkShiftId);
                iws.InternId = updateInternWorkShiftRequest.InternId.IsNullOrEmpty() ? iws.InternId : Guid.Parse(updateInternWorkShiftRequest.InternId);
                iws.CheckIn = updateInternWorkShiftRequest.CheckIn.IsNullOrEmpty() ? iws.CheckIn : DateTime.Parse(updateInternWorkShiftRequest.CheckIn);
                iws.CheckOut = updateInternWorkShiftRequest.CheckOut.IsNullOrEmpty() ? iws.CheckOut : DateTime.Parse(updateInternWorkShiftRequest.CheckOut);                
                iws.UpdateTime = DateTime.UtcNow;
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateTeamWorkShift(UpdateTeamWorkShiftRequest updateTeamWorkShiftRequest)
        {
            var ws = await _context.WorkShifts.Where(x => x.Id == updateTeamWorkShiftRequest.Id).FirstOrDefaultAsync();
            if (ws != null)
            {
                ws.StartTime = updateTeamWorkShiftRequest.StartTime.IsNullOrEmpty() ? ws.StartTime : TimeSpan.Parse(updateTeamWorkShiftRequest.StartTime);
                ws.EndTime = updateTeamWorkShiftRequest.EndTime.IsNullOrEmpty() ? ws.EndTime : TimeSpan.Parse(updateTeamWorkShiftRequest.EndTime);
                ws.Date = updateTeamWorkShiftRequest.Date.IsNullOrEmpty() ? ws.Date : DateTime.Parse(updateTeamWorkShiftRequest.Date);
                ws.Description = updateTeamWorkShiftRequest.Description.IsNullOrEmpty() ? ws.Description : updateTeamWorkShiftRequest.StartTime;
                ws.UpdateTime = DateTime.UtcNow;
                ws.ProjectId = updateTeamWorkShiftRequest.ProjectId.IsNullOrEmpty() ? ws.ProjectId : Guid.Parse(updateTeamWorkShiftRequest.ProjectId);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }
    }
}
