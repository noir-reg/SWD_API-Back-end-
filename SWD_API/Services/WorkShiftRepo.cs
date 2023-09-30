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
    }
}
