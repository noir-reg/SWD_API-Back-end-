using Microsoft.EntityFrameworkCore;
using SWD_API.Payload.Response.Account;
using SWD_API.Repository.Models;

namespace SWD_API.Services
{
    public class InternRepo : IInternRepo
    {
        private readonly SWDProjectContext _context = new();
        public List<InternModel> GetAll()
        {
            //throw new NotImplementedException();
            var intern = _context.Interns.Select(it =>
                    new InternModel
                    {
                        Id = it.Id,
                        FullName = it.FullName,
                        UniversityId = it.UniversityId,
                        MajorId = it.MajorId,
                        InternshipSemesterId = it.InternshipSemesterId,
                        TeamId = it.TeamId,
                        Dob = it.Dob,
                        Gender = it.Gender,
                        Role = it.Role,
                        Email = it.Email,
                        PhoneNumber = it.PhoneNumber,
                        Status = it.Status,
                        UpdateTime = it.UpdateTime
                    });
            return intern.ToList();
        }

        public InternModel GetById(string id)
        {
            //throw new NotImplementedException();
            var intern = _context.Interns
                .SingleOrDefault(it =>
                    it.Id == Guid.Parse(id));
            if (intern != null)
            {
                return new InternModel
                {
                    Id = intern.Id,
                    FullName = intern.FullName,
                    UniversityId= intern.UniversityId,
                    MajorId= intern.MajorId,
                    InternshipSemesterId= intern.InternshipSemesterId,
                    TeamId = intern.TeamId,
                    Dob = intern.Dob,
                    Gender = intern.Gender,
                    Role = intern.Role,
                    Email = intern.Email,
                    PhoneNumber = intern.PhoneNumber,
                    Status = intern.Status,
                    UpdateTime = intern.UpdateTime
                };
            }
            return null;
        }

        

        public async Task<IList<GetAccountResponse>> GetInternListByWorkShiftDate(Guid teamLeaderId, string workShiftDate)
        {
            var teamID = _context.Teams.Where(x => x.TeamLeaderId == teamLeaderId).Select(x => x.Id).FirstOrDefault();
            var wsId = await _context.WorkShifts.Where(x => DateOnly.FromDateTime(x.Date) == DateOnly.Parse(workShiftDate)&&x.TeamId==teamID).Select(x=>x.Id).FirstOrDefaultAsync();
            var list = await _context.Interns.Where(x => x.TeamId == teamID).Include(x => x.University).Include(x => x.Major)
               .Include(x => x.Team).Include(x => x.InternshipSemester).Select(x => new GetAccountResponse
               {
                   Id = x.Id,
                   FullName = x.FullName,
                   PhoneNumber = x.PhoneNumber,
                   Dob = x.Dob,
                   Major = x.Major == null ? null : x.Major.Name,
                   University = x.University == null ? null : x.University.Name,
                   Team = x.Team == null ? null : x.Team.Name,
                   InternshipSemester = x.InternshipSemester == null ? null : x.InternshipSemester.Name,
                   Gender = x.Gender,
                   Role = x.Role,
                   Email = x.Email,
                   Status = x.Status


               }).ToListAsync();
            return list;
        }
    }
}
